
;Converting: ----GGGG RRRRBBBB 4 bit per channel
;To:		 -----RRR -GGG-BBB 3 bit per channel


SetPalette:				;d0=Palnum d1=-GRB
	cmp.b #16,d0
	bcc SetPaletteSkip			;We're only capable of using 16 colors
		
	moveM.l d0-d2/a0,-(sp)	
		
		and.l #$000000FF,d0
		rol.l #1,d0			;2 bytes per color*2
		
		add.l #$ff8240,d0 	;$ff8240+color*2 
		move.l d0,a0
		
		
		move.w d1,d0
		and.w #$00E0,d0		;----gggg RRRrbbbb
		rol.w #3,d0			;-----RRR --------
		
		move.w d0,d2
		
		move.w d1,d0		
		and.w #$0E00,d0		;----GGGg rrrrbbbb
		ror.w #5,d0			;-------- -GGG----
		or.w d0,d2
		
		move.w d1,d0		 
		and.w #$000E,d0		;----gggg rrrrBBBb
		ror.w #1,d0			;-------- -----BBB
		or.w d0,d2
		
		move.w d2,(a0)		;Set the color

	moveM.l (sp)+,d0-d2/a0
SetPaletteSkip:
	rts