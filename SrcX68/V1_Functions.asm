
PrintString:
		move.b (a3)+,d0			;Read a character in from A3
		cmp.b #255,d0
		beq PrintString_Done	;return on 255
		jsr PrintChar			;Pritn the Character
		bra PrintString
PrintString_Done:		
	rts
	
cls:
	move.L #32*32-1,d1			;No of characters in a screen
clsAgain:
	move #' ',d0				;Show a space
	jsr PrintChar
	dbra d1,clsAgain			;Reapeat until screen is cleared
	
	clr.b d3					;Reset Text cursor
	clr.b d6
	;jsr Locate
	
Locate:	;Locate (d1,d4)=(X,Y)	
	move.b 	d3,(Cursor_X)		;Store new XY curosr position
	move.b 	d6,(Cursor_Y)
	rts
		
NewLine:
	addq.b #1,(Cursor_Y)		;CR - LF
	move.b #0,(Cursor_X)
	rts
	
PrintChar:						;D0=character
	moveM.l d0-d7/a0-a7,-(sp)
		and.l #$FF,d0
		sub.l #32,d0			;Font doesn't have chars below 32
		rol.l #3,d0				; 8 bytes per character
		move.l #Font,a1
		add.l d0,a1
		
		move.b Cursor_X,d1		;Convert X pos to Byte
		and.l #$FF,d1
		rol.l #4,d1				;2 bytes per pixel - 8 pixels per char
		
		add.l #$c00000,d1		;Screen position in memory
		bclr.l #0,d1			;Clear Bit 0
		
		move.l d1,a0
		clr.l d1
		move.b Cursor_Y,d1
			ifd TallTile
				rol.l #1,d1		;Multiple Y by 10
				move.l d1,d0
				rol.l #2,d1		
				add.l d1,d0
				move.l d0,d1
			else
				rol.l #3,d1		;Multiply Y by 8
			endif
		rol.l #8,d1				;1024 bytes per line
		rol.l #2,d1
		add.l d1,a0
		
nextChar:
		ifd TallTile
			move.l #9,d5		;Line count +10
		else
			move.l #7,d5		;Line count +7
		endif
		
nextline:
		ifd TallTile
			cmp.b #2,d5
			beq CharTallLine	;Duplicate Lines 2,5 of font
			cmp.b #5,d5
			beq CharTallLine
			bra CharNextLine
CharTallLine
			subq.l #1,a1
		endif
		
CharNextLine:
		move.l #7,d4			;Pixel count
		move.b (a1)+,d0
nextpixel:
		clr.l 	d1
		roxl.b 	#1,d0			;Pop a bit out of the font, 
		roxl.b 	#1,d1			;and into color 15 of a byte
		move.b 	d1,d2	
		rol.b 	#1,d1
		or.b 	d2,d1	
		rol.b 	#1,d1
		or.b 	d2,d1	
		rol.b 	#1,d1
		or.b 	d2,d1	
		move.w d1,(a0)+
		
		dbra d4,nextpixel
		addA #1024-16,a0		;Move down a line
		dbra d5,nextline
	
		addq.b #1,(Cursor_X)
		move.b (Cursor_X),d0
	ifd Res256x256
		cmp.b #39,d0			;Screen Width 40
	else
		cmp.b #63,d0			;Screen width 80
	endif
		bls nextpixel_Xok		;Branch if not over screenwidth
		jsr NewLine				;Move down a line
nextpixel_Xok:
	moveM.l (sp)+,d0-d7/a0-a7
	rts
	