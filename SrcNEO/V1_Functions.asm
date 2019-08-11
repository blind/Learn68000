	even
KickWatchdog:
	move.b	d0,REG_DIPSW		; kick the watchdog
	rts
	
	
	
cls:
	clr.b d3
	clr.b d6
	jsr Locate
	move.L #40*25-1,d1
clsAgain:
	move #' ',d0
	jsr PrintChar
	dbra d1,clsAgain
	rts
	
	
	
	
	

PrintChar:
	moveM.l d0-d7/a0-a7,-(sp)
	
	;move.b #2,d1 
	;move.b d1,$3C0004 	;Address INC (2 bytes per tile)
	
		and #$FF,d0
		sub #32,d0
		
		;			
		Move.L  #$7000,d5
		Move.L #0,d4
		Move.B (Cursor_X),D4
		ifd ScrWid256
			addq.b #4,d4
		endif
		;add #1,d4				;NEO doesn't recommend using leftmost column
		;rol.L #8,D4
		;rol.L #8,D4
		rol.L #5,D4
		add.L D4,D5
		
		move.L #0,d4
		Move.B (Cursor_Y),D4
		add #2,d4				;NEO doesn't recommend using top 2 columns
		;rol.L #8,D4
		;rol.L #8,D4
		;rol.L #1,D4
		add.L D4,D5
		
;		MOVE.L	D5,(A4)			; C00004 write next character to VDP
;		MOVE.W	D0,(A5)			; C00000 store next word of name data

		
	add.w #$1800,d0	;Tile Num
	
	
	

	;move.w d1,$3C0000 
	;addq #1,d1
	
	;move.w d3,$3C0002
	;addq #1,d3
	move.w d5,$3C0000 		;address
	move.w d0,$3C0002		;tile data
		
		
		
		addq.b #1,(Cursor_X)
		move.b (Cursor_X),d0
		cmp.b #39,d0
		bls nextpixel_Xok
		jsr NewLine
nextpixel_Xok:
		
	moveM.l (sp)+,d0-d7/a0-a7
	rts


	
	
	
PrintString:
		move.b (a3)+,d0
		cmp.b #255,d0
		beq PrintString_Done
		jsr PrintChar
		bra PrintString
PrintString_Done:		
	rts

NewLine:
	addq.b #1,(Cursor_Y)
	move.b #0,(Cursor_X)
	rts	
	

Locate:
	move.b d6,(Cursor_Y)
	move.b d3,(Cursor_X)
	
	rts	
	
	
		
	
	
	