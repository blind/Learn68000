	macro PushBc
		move.l d1,-(sp)
		move.l d4,-(sp)
	endm
	
	macro PopBc
		move.l (sp)+,d4
		move.l (sp)+,d1
	endm
	
	macro PushDe
		move.l d2,-(sp)
		move.l d5,-(sp)
	endm
	
	macro PopDe
		move.l (sp)+,d5
		move.l (sp)+,d2
	endm
	
	macro PushHl
		move.l d3,-(sp)
		move.l d6,-(sp)
		move.l a3,-(sp)
	endm
	
	macro PopHl
		move.l (sp)+,a3
		move.l (sp)+,d6
		move.l (sp)+,d3
	endm
	
	macro PushAf
		move.l d0,-(sp)
		
	endm
	
	macro PopAf
		move.l (sp)+,d0
	endm
	
	
	macro PushAll
		moveM.l d0-d7/a0-a7,-(sp)
	endm
	macro PopAll
		moveM.l (sp)+,d0-d7/a0-a7
	endm