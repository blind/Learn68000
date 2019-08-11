;	org $38000
UserRam equ $30000		;Don't try this at home! may corrupt part of the OS if we're unlucky
	
	Trap #0						;Supervisor mode
	ori #0700,sr				;Disable interrupts
	
	ifd Mode4Color
		move.b #%00000000,$18063	;Force 4 color mode!
	else
		move.b #%00001000,$18063	;Force 8 color mode!
	endif
	
	