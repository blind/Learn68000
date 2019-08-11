;Mode4Color equ 1			;Sinclair QL Only

Cursor_X equ UserRam
Cursor_Y equ UserRam+1

	include "\SrcALL\BasicMacros.asm"
	include "\SrcALL\V1_Header.asm"

	

	move.b #'A',d0
	jsr PrintChar
	
	move.b #'B',d0
	jsr PrintChar
	move.b #'C',d0
	jsr PrintChar
	
		jsr NewLine
	
	lea Message,a3
	jsr PrintString
	jsr NewLine
	ifd BuildAMI
BitmapMode equ 1
	endif
	ifd BuildAST
BitmapMode equ 1
	endif
	ifd BuildX68
BitmapMode equ 1
	endif
	ifd BuildSQL
BitmapMode equ 1
	endif
	ifd BuildNEO
TileMode equ 1
	endif
	ifd BuildGEN
TileMode equ 1
	endif
	
	ifd TileMode
		move.l #3,d0	;SX
		move.l #3,d1	;SY
	
		move.l #6,d2	;WID
		move.l #6,d3	;HEI
	
		move.l #256,d4	;TileStart Number
		jsr FillAreaWithTiles
	endif
	
	ifd BuildGEN
		lea Bitmap,a0					;Source data
		move.w #BitmapEnd-Bitmap,d1
		move.l #256*32,d2				;32 bytes per tile
		jsr DefineTiles	
	endif
	
	ifd BitmapMode
	move.b #3,d1			;x
	move.b #32,d2			;y
	jsr GetScreenPos		;Get Position in Vram
	
	move.l #48-1,d2			;Height
	lea Bitmap,a0
BmpNextLine:			
	ifnd Mode4Color
		move.l #(48/2)-1,d1		;4 pixels per word in 8 color mode
	else
		move.l #(48/4)-1,d1		;8 pixels per word in 4 color mode
	endif
	move.l a6,-(sp)
BmpNextPixel:
	ifd BuildSQL
		move.b (a0)+,(a6)+		
		
	endif	
	ifd BuildX68			;Note, each pixel is 2 bytes in ram
		move.b (a0),d0
		ror #4,d0			;Copy Top Nibble
		move.w d0,(a6)+
		move.b (a0)+,d0		;Copy Bottom Nibble
		move.w d0,(a6)+
	endif
	
	ifd BuildAST				;Amiga Format (byte bitplanes)
		move.b (a0)+,(a6)		;Bitplane 0
		move.b (a0)+,(2,a6)		;Bitplane 1
		move.b (a0)+,(4,a6)		;Bitplane 2
		move.b (a0)+,(6,a6)		;Bitplane 3	
		
		move.l a6,d3
		addq.l #1,a6
		
		btst.l #0,d3			;We need to shift 7 pixels every 2 bytes because 4 word bitplanes are together in memory
		beq BmpNextPixelEven
		addq.l #6,a6
BmpNextPixelEven
		subq.l #3,d1			;Dbra wil sub 1 - but we need to sub another 3 as we do 4 bytes per update
	endif
	
	
	
	; ifd BuildAMI				;This will read the same file as the AST
		; move.b (a0)+,(a6)		;Read in word chunks!
		; move.b (a0)+,(1,a6)
		; move.b (a0)+,(40*200*2,a6)
		; move.b (a0)+,(40*200*2+1,a6)
		; move.b (a0)+,(40*200*3,a6)	;4 bitplanes
		; move.b (a0)+,(40*200*3+1,a6)
		; move.b (a0)+,(40*200*1,a6)
		; move.b (a0)+,(40*200*1+1,a6)
		; addq.l #2,a6
		; subq.l #7,d1
	; endif
	ifd BuildAMI				
		move.b (a0)+,(a6)		
		move.b (a0)+,(40*200*1,a6)
		move.b (a0)+,(40*200*2,a6)	;4 bitplanes
		move.b (a0)+,(40*200*3,a6)
		addq.l #1,a6
		subq.l #3,d1
	endif
		dbra d1,BmpNextPixel
	move.l (sp)+,a6				;Get the left Xpos back
	jsr GetNextLine
	dbra d2,BmpNextLine
	

	endif
	
	
	
	
	lea Palette,a0		;Source palette
	clr.l d0			;Color number
PaletteNext:
	move.w (a0)+,d1		;Read Definition
	jsr SetPalette		;Set Color D0 to D1 (-GRB)
	
	addq.b #1,d0
	cmp.b #17,d0		;Repeat for other colors
	bne PaletteNext
	
	
	
	
	jmp *

	
	
	
	
	
	

	

	

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	
	include "\SrcALL\V1_Palette.asm"
	include "\SrcALL\V1_BitmapMemory.asm"
	include "\SrcALL\V1_VdpMemory.asm"
	include "\SrcALL\V1_Functions.asm"
	include "\SrcALL\Multiplatform_Monitor.asm"
	include "\SrcALL\V1_DataArea.asm"
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;				Data Area
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	ifnd BuildNEO			;NeoGeo Doesn't use font
Font:
	incbin "\ResALL\Font96.FNT"
	endif
Bitmap:
	ifd BuildX68
		incbin "\ResALL\Sprites\RawMSX.RAW"
	endif	
	ifd BuildGEN
		incbin "\ResALL\Sprites\RawMSXVdp.RAW"
	endif
	ifd BuildAST
		incbin "\ResALL\Sprites\RawAMI.RAW"
	endif
	ifd BuildAMI
		incbin "\ResALL\Sprites\RawAMI.RAW"
	endif
	ifd BuildSQL
		ifd Mode4Color
			incbin "\ResALL\Sprites\RawQL4.RAW"
		else
			incbin "\ResALL\Sprites\RawQL.raw"
		endif
	endif
BitmapEnd:
	even
Palette:
	;     -grb
	dc.w $0000	;0 - Background
	dc.w $0099	;1
	dc.w $0E0F	;2
	dc.w $0FFF	;3
	dc.w $000F	;4
	dc.w $004F	;5
	dc.w $008F	;6
	dc.w $00AF	;7
	dc.w $00FF	;8
	dc.w $04FF	;9
	dc.w $08FF	;10
	dc.w $0AFF	;11
	dc.w $0CCC	;12
	dc.w $0AAA	;13
	dc.w $0888	;14
	dc.w $0444	;15
	dc.w $0000	;Border
	even

Message: dc.b 'Hello World!!!',255
	even
	include "\SrcALL\V1_RamArea.asm"
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;				Ram Area - May not be possible on all systems!!!
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	include "\SrcALL\V1_Footer.asm"