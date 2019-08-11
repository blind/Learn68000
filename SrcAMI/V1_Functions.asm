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
		and.l #$FF,d0
		sub #32,d0
		rol.l #3,d0
		move.l #Font,a1
		add d0,a1
		
		
		
		
		;add.l #$c00000,d1
		
		;bclr.l #0,d1			;Clear Bit 0
		
		
		move.l  #screen_mem,a0  ; Move address to screen mem to d0
		;add.l   #$ff,d0         ; Add 255 d0 address
		;clr.b   d0              ; Clear lowest byte in address
		;move.l  d0,a0           ; Store screen pointer in a6
		
				
		moveq.l #0,d1
		move.b Cursor_X,d1
		ifd ScrWid256
			addq.b #4,d1
		endif
		;and.l #1,d1
		add.l d1,a0
		
		;move.b Cursor_X,d1
		;and.l #%11111110,d1
		
		;rol.l #2,d1
		;add.l d1,a0
		
		moveq.l #0,d1
		move.b Cursor_Y,d1
		mulu #40*8,d1
		add.l d1,a0
		
		
nextChar:
		move.l #7,d5
nextline:
		move.l #7,d4
		move.b (a1)+,d0
nextpixel:
		move.b  d0,(a0)
		move.b  d0,(40*200,a0)
		move.b  d0,(40*200*2,a0)
		move.b  d0,(40*200*3,a0)
		;move.b #0,(2,a0)
		;move.b #0,(4,a0)
		;move.b #0,(6,a0)
		;move.w  d0,2(a1)
		;move.w  d0,4(a1)
		;move.w  d0,6(a1)
		;moveq #0,d1
		;roxl.b #1,d0
		;roxl.b #1,d1
		;move.b #1,d1	;Remove Me
		;move.b d1,(a0)+
		;dbra d4,nextpixel
		addA #40,a0
		dbra d5,nextline
	
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
	
	
		