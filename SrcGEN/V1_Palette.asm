
;Converting: ----GGGG RRRRBBBB 4 bit per channel
;To:		 ----BBB- GGG-RRR- 3 bit per channel

SetPalette:		;d0=Palnum d1=-GRB
	
	cmp #16*4,d0			;16 colors per palette , 4 palettes
	bge SetPaletteSkip
	
	moveM.l d0-d2,-(sp)

		and.l #$FF,d0
		rol.b #1,d0
		rol.l #8,d0
		rol.l #8,d0
		or.l #$C0000000,d0	;%C0pp0000 
		move.l d0,(VDP_ctrl) ;pp=palette entry (2 bytes each 00-7F)
		
		move.w d1,d0
		and.w #$00E0,d0		;----gggg RRRrbbbb
		ror.w #4,d0			;-------- ----RRR-
		
		move.w d0,d2
		
		move.w d1,d0		
		and.w #$0E00,d0		;----GGGg rrrrbbbb
		ror.w #4,d0			;-------- GGG-----
		or.w d0,d2
		
		move.w d1,d0		 
		and.w #$000E,d0		;----gggg rrrrBBBb
		rol.w #8,d0			;----BBB- --------
		or.w d0,d2
		
		move.w d2,(VDP_data)	
	
	moveM.l (sp)+,d0-d2
SetPaletteSkip
	rts
	
	