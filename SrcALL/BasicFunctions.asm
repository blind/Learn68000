CLDIR:
	move.l a3,a2
	move.b d0,(a2)+
LDIR:
	subq.l #1,d1 	
LDIRAgain:
	move.b (a3)+,(a2)+
	dbra d1,LDIRAgain
	rts
