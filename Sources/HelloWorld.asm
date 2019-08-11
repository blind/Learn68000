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


	
		  ;;---XNZVC
	;andi #%00001111,SR
	;move.l #0,d3
	;move.l #8,d0
	;move.l #$90,d2

	
	;abcd d2,d0	 
	;abcd d3,d1
	
	
	;move.l d1,-(sp)
	;jsr Monitor_PushedRegister
	;move.l d0,-(sp)
	;jsr Monitor_PushedRegister
	
	;abcd d2,d0
	;abcd d3,d1
	
		;move.l d1,-(sp)
	;jsr Monitor_PushedRegister
	;move.l d0,-(sp)
	;jsr Monitor_PushedRegister
	;jsr NewLine
	ifd BuildX68
BitmapMode equ 1
	endif
	ifd BuildSQL
BitmapMode equ 1
	endif
	
	ifd TileMode
		move.l #3,d0	;SX
		move.l #3,d1	;SY
	
		move.l #6,d2	;WID
		move.l #6,d3	;HEI
	
		move.l #256,d4	;TileStart
	
		jsr FillAreaWithTiles
	endif
	
	
	ifd BuildGEN
		lea Bitmap,a0					; MOVE does not work on Genesis
		move.w #BitmapEnd-Bitmap,d1
		move.l #256*32,d2	;32 bytes per tile
		jsr DefineTiles	
	endif
	
	ifd BitmapMode
	move.b #2,d1	;x
	move.b #64,d2	;y
	jsr GetScreenPos
	
	move.l #48-1,d2
	lea Bitmap,a0
BmpNextLine:			
	move.l #(48/2)-1,d1
	move.l a6,-(sp)
BmpNextPixel:
	ifd BuildSQL
		move.b (a0)+,(a6)+		
	endif	
	ifd BuildX68		
		move.b (a0),d0
		ror #4,d0
		move.w d0,(a6)+
		move.b (a0)+,d0
		move.w d0,(a6)+
		
	endif
	ifd BuildAST
		;move.b (a0)+,(a6)+				;AST Format
		
		
		move.b (a0)+,(a6)				;Amiga Format
		move.b (a0)+,(2,a6)
		move.b (a0)+,(4,a6)
		move.b (a0)+,(6,a6)
		
		move a6,d3
		addq.l #1,a6
		
		Btst.l #0,d3			;We need to shift 7 pixels every 2 bytes because bitplanes are by word not byte
		beq BmpNextPixelEven
		addq.l #6,a6
BmpNextPixelEven
		subq.l #3,d1
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
	ifd BuildAMI				;This will read the same file as the AST
		move.b (a0)+,(a6)		;Read in word chunks!
		move.b (a0)+,(40*200*2,a6)
		move.b (a0)+,(40*200*3,a6)	;4 bitplanes
		move.b (a0)+,(40*200*1,a6)
		addq.l #1,a6
		subq.l #3,d1
	endif
	dbra d1,BmpNextPixel
	move.l (sp)+,a6
	jsr GetNextLine
	dbra d2,BmpNextLine
	

	endif
	
	lea Palette,a0
	move.l #17,d4

PaletteNext:
	move.l #17,d0
	sub.b d4,d0
	move.w (a0)+,d1
	jsr SetPalette
	subq.b #1,d4
	cmp.b #0,d4
	bne PaletteNext
	
	jmp *
	
	;jsr Monitor
	;move.l #$12345678,d0
	
	;jsr Monitor_PushedRegister
	;jsr NewLine
	
	
	;move.l #$00000000,d0
	;move.l d0,-(sp)
	;jsr Monitor_ShowPushedReg
	
;	jsr Monitor


;	jsr Monitor_MemDump;
;	dc.l $00000000
;	dc.w $6
	;jsr KeyboardScanner_AllowJoysticks
	
	KAgain:	
	move.b #0,d3
	move.b #10,d6
	jsr Locate
	jsr Player_ReadControlsDual
	jsr monitor
	
	jmp KAgain
	
	
	
inf:
	move.b #0,(Cursor_Y)
	move.b #0,(Cursor_X)
	move.l d0,-(sp)
	jsr Monitor_PushedRegister

	move.l #$0000FFFF,d2
Pauser:	
	dbra d2,Pauser
	addq.l #1,d0
	move.l d0,-(sp)
;	jsr ChibiSound
	move.l (sp)+,d0
	

	ifd BuildNEO
		jsr KickWatchdog
	endif
	
	jmp inf
	

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	
	;JoyTest
	;jsr Player_ReadControlsDual
	;jsr Monitor
	
	
	;move.l d1,-(sp)
	;move.l d0,-(sp)
	;jsr Monitor_PushedRegister
	;move.l (sp)+,d0
	;move.l d0,-(sp)
	;jsr Monitor_PushedRegister
	
	include "\SrcALL\V1_ReadJoystick.asm"
	;include "\SrcX68\V1_BitmapMemory.asm"
	;include "\SrcX68\V1_BitmapMemory.asm"
	
	;include "\SrcNEO\V1_VdpMemory.asm"
	;include "\SrcGEN\V1_VdpMemory.asm"
	include "\SrcALL\V1_Palette.asm"
	;include "\SrcGEN\V1_Palette.asm"
	;include "\SrcAST\V1_BitmapMemory.asm"
	;include "\SrcAMI\V1_BitmapMemory.asm"
	include "\SrcALL\V1_BitmapMemory.asm"
	;include "\SrcX68\V1_Palette.asm"
	;include "\SrcNEO\V1_Palette.asm"
	;include "\SrcAST\V1_Palette.asm"
	;include "\SrcAMI\V1_Palette.asm"
	
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
		
		;incbin "X:\ResALL\Sprites\SpriteAMI.RAW"
		;incbin "x:\ResALL\Sprites\RawMSX.RAW"
	endif
	ifd BuildAST
		incbin "\ResALL\Sprites\SpriteAMI.RAW"
		;incbin "X:\ResALL\Sprites\SpriteAST.RAW"
	endif
	ifd BuildAMI
		;incbin "X:\ResALL\Sprites\SpriteAST.RAW"
		incbin "\ResALL\Sprites\SpriteAMI.RAW"
	endif
	ifd BuildSQL
		;incbin "X:\ResALL\Sprites\SpriteAST.RAW"
		incbin "\ResALL\Sprites\RawQL.raw"
	endif
BitmapEnd:
	even
Palette:
	;     -grb
	dc.w $0000	;0 - Background
	dc.w $0099	;1
	dc.w $0E0F	;2
	dc.w $0FFF	;3 - Last color in 4 color modes
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