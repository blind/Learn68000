;Convert: ----GGGG RRRRBBBB
;     To: ----RRRR GGGGBBBB

SetPalette:		;d0=Palnum d1=-GRB
	
	moveM.l d0-d7/a0-a7,-(sp)
		move.l #$400020,a0	;We start from Palette 1 
								;as palette 0 is special!
		and.l #$FF,d0
		rol.b #1,d0			;2 bytes per color
		add.l d0,a0			;offset for selected color
	
		move.w d1,d3
		and.w #$000F,d3		;B
		
		move.w d1,d2		
		and.w #$0F00,d2		;G
		ror.w #4,d2
		
		and.w #$00F0,d1		;R
		rol.w #4,d1
		
		or.w d2,d1			;Combine RGB
		or.w d3,d1
			
		move.w d1,(a0)		;Copy to Palette
		
		cmp #0,d0			;Are we setting background color?
		bne SetPaletteSkipb
		move.w d1,($401FFE)	;Backdrop Color
		move.w d1,($400004)	;Color used for 'off screen' Border
SetPaletteSkipb	
	moveM.l (sp)+,d0-d7/a0-a7
	rts
	
	
	
	