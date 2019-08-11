
BCD_Show:
	move.b (a0)+,d0
	;move.b d1,-(sp)
	jsr PrintBCDChar		
	;move.b (sp)+,d1
	dbra  d1,BCD_Show
	rts


PrintBCDChar:
	move.b d0,-(sp)
		and.b #$F0,d0
		ror.b #4,d0
		jsr PrintBCDCharOne	
	move.b (sp)+,d0
	and.b #$0F,d0
PrintBCDCharOne:	
	add.b #'0',d0
	jsr PrintChar
	rts
	
BCD_Add:
		   ;---XNZVC
	andi  #%00001111,CCR	; Clear extend
	and.l #$000000FF,d1
	addq #1,d1
	add.l d1,a0
	add.l d1,a1
	subq #1,d1
BCD_AddAgain:
	ABCD -(a1),-(a0)
	dbra  d1,BCD_AddAgain
	rts

BCD_Subtract
	 	   ;---XNZVC
	andi  #%00001111,CCR	; Clear extend
	and.l #$000000FF,d1
	addq #1,d1
	add.l d1,a0
	add.l d1,a1
	subq #1,d1
BCD_SubAgain:
	SBCD -(a1),-(a0)
	dbra  d1,BCD_SubAgain
	rts

	