
Player_ReadControlsDual:;---7654S321RLDU
	move.b #%00111111,$BFE201	;Direction for port A (BFE001)....0=in 1=out... 
								;(For fire buttons)

	move.w $dff00A,d2			;Joystick-mouse 0 data (vert,horiz) (Joy2)
	
	move.b $bfe001,d5			;/FIR1 /FIR0  /RDY /TK0  /WPRO /CHNG /LED  OVL
	rol.b #1,d5					;Fire0 for joy 2
	
	bsr Player_ReadControlsOne	;Process Joy2
	
	move.l d0,-(sp)
		move.w $dff00c,d2		;Joystick-mouse 1 data (vert,horiz) (Joy1)
		move.b $bfe001,d5		;/FIR1 /FIR0  /RDY /TK0  /WPRO /CHNG /LED  OVL
	
		bsr Player_ReadControlsOne ;Process Joy 1
	move.l (sp)+,d1
KeyboardScanner_AllowJoysticks:
	rts
	
	
	
Player_ReadControlsOne:	;Translate HV data into joystick values
	clr.l d0	
	clr.l d1
	clr.l d3
	clr.l d4
	
	;Get the 4 bits that are needed for the directions
	roxr.l #1,d2	;bit 0
	roxl.l #1,d3
	
	roxr.l #1,d2	;bit 1
	roxl.l #1,d4
	
	roxr.l #7,d2	;bit 8
	roxl.l #1,d0
	
	and.l #1,d2		;bit 9
	
	;Calculate the new directions
	move.b d2,d1
	eor.b d0,d1
	roxr.b d1
	roxr.b d0		;Up (Bit 9 Xor 8)
	
	move.b d4,d1
	eor.b d3,d1
	roxr.b d1
	roxr.b d0		;Down (Bit 1 Xor 0)
	
	roxr.b d2
	roxr.b d0		;Left (Bit 9)
	
	roxr.b d4
	roxr.b d0		;Right (Bit 1)
	
	
	roxl.b d5
	roxr.b d0		;Fire
	
	ror.b #3,d0
	eor.b #%11101111,d0	;Invert UDLR bits
	or.l #$FFFFFF00,d0	;Set unused bits
	rts
	
;Direction	Bit in $DFF0A/C
;Right		1
;Left		9
;Down		1 XOR 0
;UP 		9 XOR 8
