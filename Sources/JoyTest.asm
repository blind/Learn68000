
;NeoJoy_UseBios equ 1


Cursor_X equ UserRam
Cursor_Y equ UserRam+2

	include "\SrcALL\BasicMacros.asm"
	include "\SrcALL\V1_Header.asm"

	jsr KeyboardScanner_AllowJoysticks	;Turn on joysticks on systems that need init
	
KAgain:	
	move.b #0,d3
	move.b #0,d6
	jsr Locate
	
	jsr Player_ReadControlsDual		;Get Joystick state
	jsr monitor
	
	jmp KAgain

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	
	include "\SrcALL\V1_ReadJoystick.asm"
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
		incbin "\ResALL\Sprites\SpriteAMI.RAW"
		
	endif
	ifd BuildAMI
		
		incbin "\ResALL\Sprites\SpriteAMI.RAW"
	endif
	ifd BuildSQL
		
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

Message: dc.b 'Hello World?!!',255
	even
	include "\SrcALL\V1_RamArea.asm"
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;				Ram Area - May not be possible on all systems!!!
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	include "\SrcALL\V1_Footer.asm"