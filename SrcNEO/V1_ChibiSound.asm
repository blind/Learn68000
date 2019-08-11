ChibiSound:					;NVVTTTTT	Noise Volume Tone 
	move.b d0,d1
	and.b #%00001111,d0		;Set top bit to 1 - low byte commands have special meaning for the system
	or.b #%10000000,d0		;Set top bit to 1 - low byte commands have special meaning for the system
	move.b	d0,$320000 	;Send a byte to the Z80 
ChibiSoundWait:	
	move.b	$320000,d0 	;Get byte from Z80
	cmp.b #255,d0
	bne ChibiSoundWait	;Wait until procesed
	move.b d1,d0
	and.b #%11110000,d0		;Set top bit to 1 - low byte commands have special meaning for the system
	ror #4,d0
	or.b #%11000000,d0		;Set top bit to 1 - low byte commands have special meaning for the system
	move.b	d0,$320000 	;Send a byte to the Z80 
	
	rts