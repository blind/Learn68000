cls:
	clr.b d3
	clr.b d6
	jsr Locate
	move.L #40*25-1,d1					;Fill the screen with space characters
clsAgain:
	move #' ',d0
	jsr PrintChar
	dbra d1,clsAgain
	rts
	
PrintChar:
	moveM.l d0-d7/a0-a7,-(sp)
		and.l #$FF,d0
		sub #32,d0						;No space in our font
		rol.l #3,d0						;8 pixels per char
		move.l #Font,a1
		add d0,a1
		
		move.l ScreenBase,a0           	;Get screen pos from memory
				
		clr.l d1
		move.b Cursor_X,d1				
		
		and.l #%00000001,d1				;Odd characters need to be offset by 1 byte
		add.l d1,a0
		
		move.b Cursor_X,d1
		and.l #%11111110,d1
		ifd ScrWid256
			addq.b #4,d1
		endif
		rol.l #2,d1						;4 Bitplane words consecutive in memory
		add.l d1,a0
		
		move.b Cursor_Y,d1
		mulu #160*8,d1					;160 bytes per line - 8 lines per char
		add.l d1,a0
		
nextChar:
		move.l #7,d5					;7 lines
nextline:	
		move.l #7,d4					;7 Pixels per line
		move.b (a1)+,d0
nextpixel:			
;pixels are stored in words clusers , eg 1234,ABCD = pixel 1234, then bitplane , so ABCD= second bitplane of pixels 1234 etc
		move.b  d0,(a0)				
		move.b  d0,(2,a0)
		move.b  d0,(4,a0)
		move.b  d0,(6,a0)
		addA #160,a0
		dbra d5,nextline				;Next line of the character
	
		addq.b #1,(Cursor_X)
		move.b (Cursor_X),d0
		cmp.b #39,d0					;See if we've gone over the line
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
	
	
		
