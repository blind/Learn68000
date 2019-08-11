

		

printChar:
	moveM.l d0-d4/a1-a2,-(sp)
		lea Font,a2
		
		and.l #$FF,d0
		sub.b #32,d0			;Our font has no space
		
		ifd ScrWid256
			add.l #4*8,d2		;Move Y down 32 lines to simulate
		endif					;	 a 256*192 screen 
		
		roxl.l #3,d0
		add.l d0,a2
		
		
		move.l #$00020000,a1	;Screen starts at $20000
		clr.l d1

		move.b (Cursor_X),d1
		ifnd Mode4Color
			roxl.l #2,d1		;4 bytes per char in 8 color mode
		else
			roxl.l #1,d1		;1 bytes per char in 4 color mode
		endif
		add.l d1,a1
		clr.l d1

		move.b (Cursor_Y),d1
		roxl.l #8,d1			;Multiply Y by 1024 (8 lines - 128 bytes per line)
		roxl.l #2,d1
		add.l d1,a1
		move.l #7,d4
NextCharLine:	
		
		
		ifnd Mode4Color
			move.b (a2)+,d0	
			move.l #1,d3
NextCharPart:
			clr.w d1
			clr.w d2
			roxl.b #1,d0		;Bit shift 4 of the 8 bits into even positions in the byte
			roxl.b #2,d1
			roxl.b #1,d0
			roxl.b #2,d1
			roxl.b #1,d0
			roxl.b #2,d1
			roxl.b #1,d0
			roxl.b #2,d1
			move.b d1,d2
			roxr.w #8,d2
			or.w d1,d2			;Or in the same bits in odd positions... this makes all characters white
			roxr.w #1,d2
			or.w d1,d2
			move.w d2,(a1)+
			dbra d3,NextCharPart
			add.l #128-4,a1
		else
			move.b (a2),(a1)+	;copy the font into both words, making it white
			move.b (a2)+,(a1)+
			add.l #128-2,a1
		endif
		
		dbra d4,NextCharLine
		
		lea Cursor_X,a2		
		addq.b #1,(a2)			;Move cursor across 1
		move.b (a2),d0
		ifnd Mode4Color
			cmp.b #31,d0		;are we at the end of the screen?
		else
			cmp.b #63,d0
		endif
		bls nextpixel_Xok	
		jsr NewLine				;If so, we need to move to the next line.
nextpixel_Xok:
		
	moveM.l (sp)+,d0-d4/a1-a2
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
	;lea Cursor_X,a3
	;lea Cursor_Y,a4
	addq.b #1,(Cursor_Y)
	move.b #0,(Cursor_X)
	rts	
	
cls:
	clr.b d3
	clr.b d6
	jsr LocateB
	;move.L #32*28-1,d1
	move.L #(32*32)-1,d1
clsAgain:
	move.b #' ',d0
	jsr PrintChar
	dbra d1,clsAgain
	rts
	
Locate:
		ifd ScrWid256
			add.l #4,d6
		endif
LocateB:		
		;lea Cursor_X,a3
		;lea Cursor_Y,a4
		

		
		move.b d3,(Cursor_X)
		move.b d6,(Cursor_Y)
	rts	
	