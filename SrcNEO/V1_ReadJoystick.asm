
Player_ReadControlsDual:	;---7654S321RLDU
	
	ifd NeoJoy_UseBios
		;P4-Sel,P4-Strt,P3-Sel,P3-Strt,P2-Sel,P2-Strt,P1-Sel,P1-Strt
		move.b $10FDAC,d3	
							;Select Doesn't work on MVS
		move.b $10FD94+2,d4	;Joy1 - DCBARLDU
	else
		;AES/MVS, WritePro,CardIns 2, CardIns 1, P2-Sel,P2-Strt,P1-Sel,P1-Strt
		move.b $380000,d3	
		move.b $300000,d4	;Joy1 - DCBARLDU
	endif
		
	jsr Player_ReadControlsOne
	
	move.l d4,d0
		
	ifd NeoJoy_UseBios
		move.b $10FD9A+2,d4	;Joy2 - DCBARLDU
	else
		move.b $340000,d4	;Joy2 - DCBARLDU
	endif
	jsr Player_ReadControlsOne
	move.l d4,d1	
KeyboardScanner_AllowJoysticks:
	rts
	
Player_ReadControlsOne:
	and.l #$000000FF,d4
	clr.l d2
	roxl.b #1,d4	;Shift off button D
	roxl.b #1,d2
	
	roxr.b #1,d3	;Get Start
	roxr.b #1,d4
	roxr.b #1,d3	;Skip select
	
	rol.l #8,d2
	or.l d2,d4		;Or in Button D to bit 8
	ifd NeoJoy_UseBios
		eor.l #$FFFFFFFF,d4	;Flip all bits if reading bios
	else
		eor.l #$FFFFFE00,d4	;Flip unused bits if reading direct
	endif
	rts
	
	
	