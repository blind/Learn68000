
;Converting: ----GGGG RRRRBBBB 4 bit per channel
;To:		 GGGGGRRR RRBBBBB- 5 bit per channel

SetPalette:					;d0=Palnum d1=-GRB
	moveM.l d0-d2/a0,-(sp)	
		and.l #$000000FF,d0		;Palette number
		rol.l #1,d0				;2 Bytes per entry
		
		add.l #$e82000,d0 		;$e82000+color*2 
		move.l d0,a0
		
		clr.l d2
		
		move.l d1,d0			;Green Entry
		and.w #$0F00,d0			
		rol.l #4,d0
		or.w d0,d2
		
		move.l d1,d0			;Red Entry
		and.w #$00F0,d0
		rol.l #3,d0
		or.w d0,d2
		
		move.l d1,d0
		and.w #$000F,d0			;Blue entry
		rol.l #2,d0
		or.w d0,d2

		move.w d2,(a0)			;Set Palette Entry 
	moveM.l (sp)+,d0-d2/a0
	rts
	
	
	