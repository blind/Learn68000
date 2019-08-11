
;-----------------------------------------------------------------------

Delay		MOVE.W	#$95CE,D1	; delay a long time (about 1/20 sec?)
.1		DBRA	D1,.1
		DBRA	D0,Delay
		RTS



PrintChar:
	moveM.l d0-d7/a0-a7,-(sp)
		and #$FF,d0
		sub #32,d0
PrintCharAlt:		
		;			
		Move.L  #$40000003,d5
		Move.L #0,d4
		Move.B (Cursor_Y),D4
		ifd ScrWid256
			add.B #2,D4
		endif
		rol.L #8,D4
		rol.L #8,D4
		rol.L #7,D4
		;rol.L #2,D4
		add.L D4,D5
		
		Move.B (Cursor_X),D4
		ifd ScrWid256
			add.B #4,D4
		endif
		rol.L #8,D4
		rol.L #8,D4
		rol.L #1,D4
		add.L D4,D5
		
		MOVE.L	D5,(VDP_ctrl)			; C00004 write next character to VDP
		MOVE.W	D0,(VDP_data)			; C00000 store next word of name data

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
	
	
	
	
	
	
FontINIT:

	move.L 	#96*8,d6
	lea Font,A1
	MOVE.L	#$40000000,(VDP_Ctrl)			; Start writes to address zero
	
NextFont:
	MOVE.B	(A1)+,d0
	
	move.L 	#0,d1
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	rol.L   #3,d1
	
	roxl.B	#1,d0
	roxl.L	#1,d1
	
	move.l d1,d0
	
	rol.l #1,d1
	or.l d0,d1
	rol.l #1,d1
	or.l d0,d1
	rol.l #1,d1
	or.l d0,d1
	
	MOVE.L	d1,(VDP_Data)	;  write next longword of charset to VDP

	DBRA	D6,NextFont		; loop until done
	rts
	

	
	
	
	
	
	
	
	

