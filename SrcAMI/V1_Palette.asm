
;Converting: ----GGGG RRRRBBBB
;To:		 ----RRRR GGGGBBBB

SetPalette:		;d0=Palnum d1=-GRB
	 
	cmp #32,d0			;32 palettes on the Amiga (second 16 used by sprites)
	bge SetPaletteSkip
	
	moveM.l d0-d2/a0,-(sp)
		
		lea PalettePointer,a0	;Address of palettes in our copperlist
		move.l (a0),a0
		
		and.l #$000000FF,d0
		rol.l #2,d0				;copper commands are 4 bytes
		addq.l #2,d0			;Right 2 bytes are copper command
		add.l d0,a0 	
		
		move.w d1,d0			
		and.w #$00F0,d0			;----gggg RRRRbbbb
		rol.w #4,d0				;----RRRR --------
		
		move.w d0,d2
		
		move.w d1,d0
		and.w #$0F00,d0			;----GGGG rrrrbbbb
		ror.w #4,d0				;-------- GGGG----
		or.w d0,d2
		
		move.w d1,d0			;----gggg rrrrBBBB
		and.w #$000F,d0			;-------- ----BBBB
		or.w d0,d2
		
		move.w d2,(a0)
		
	moveM.l (sp)+,d0-d2/a0
SetPaletteSkip
	rts
	
	
 ; NAME		ADD FUNCTION
 ; COLOR00	180	Color table 00
 ; COLOR01	182	Color table 01
 ; COLOR02	184	Color table 02
 ; COLOR03	186	Color table 03
 ; COLOR04	188	Color table 04
 ; COLOR05	18A	Color table 05
 ; COLOR06	18C	Color table 06
 ; COLOR07	18E	Color table 07
 ; COLOR08	190	Color table 08
 ; COLOR09	192	Color table 09
 ; COLOR10	194	Color table 10
 ; COLOR11	196	Color table 11
 ; COLOR12	198	Color table 12
 ; COLOR13	19A	Color table 13
 ; COLOR14	19C	Color table 14
 ; COLOR15	19E	Color table 15
 ; COLOR16	1A0	Color table 16
 ; COLOR17	1A2	Color table 17 ... Sprite 0/1 Color 1
 ; COLOR18	1A4	Color table 18 ... Sprite 0/1 Color 2
 ; COLOR19	1A6	Color table 19 ... Sprite 0/1 Color 3
 ; COLOR20	1A8	Color table 20
 ; COLOR21	1AA	Color table 21 ... Sprite 2/3 Color 1
 ; COLOR22	1AC	Color table 22 ... Sprite 2/3 Color 2
 ; COLOR23	1AE	Color table 23 ... Sprite 2/3 Color 3
 ; COLOR24	1B0	Color table 24
 ; COLOR25	1B2	Color table 25 ... Sprite 4/5 Color 1
 ; COLOR26	1B4	Color table 26 ... Sprite 4/5 Color 2
 ; COLOR27	1B6	Color table 27 ... Sprite 4/5 Color 3
 ; COLOR28	1B8	Color table 28
 ; COLOR29	1BA	Color table 29 ... Sprite 6/7 Color 1
 ; COLOR30	1BC	Color table 30 ... Sprite 6/7 Color 2
 ; COLOR31	1BE	Color table 31 ... Sprite 6/7 Color 3
