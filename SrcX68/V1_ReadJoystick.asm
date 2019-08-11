
Player_ReadControlsDual:		;Returns: ---7654S321RLDU

	move.l #$E9A003,a0			;Select Joystick # 2
	jsr JoystickProcessOne		;Process buttons
	move.l d0,-(sp)				;Back up result
	
		move.l #$E9A001,a0		;Select Joystick # 1
		jsr JoystickProcessOne	;Process buttons
	
	move.l (sp)+,d1				;Get Result of joy 2 back
	rts
	
	
	
JoystickProcessOne:			;Returns: ---7654S321RLDU
	clr.l d0
	
;	         76543210
	move.b #%00000000,$E9A005	;8255 Port C (Default Controls)
	move.b (a0),d1				;-21-RLDU
	roxr.b d1
	roxr.b d0	;U
	roxr.b d1
	roxr.b d0	;D
	roxr.b d1
	roxr.b d0	;L
	roxr.b d1
	roxr.b d0	;R
	roxr.b #2,d1				;skip -
	
	roxr.b d0	;F1
	roxr.b d1
	roxr.b d0	;F2
	
	;	     76543210
	move.b #%00110000,$E9A005	;8255 Port C (Get Extra Controls)
	move.b (a0),d1				;-S3-M654 ?
	move.b d1,d3
	roxr.b #6,d1				;-------S 3	
	roxr.b d0	;F3
	roxr.b d1
	roxr.b d0	;Start
	
	and.l #$0000000F,d3			;____M654
	rol.l #8,d3
	
	or.l d3,d0
	or.l #$FFFFF000,d0
KeyboardScanner_AllowJoysticks:
	rts	
	
	