

ShowReg:
	
		move.w #$0000,d0
		move.b (a0),d0
		bsr PrintHex
		move.b (1,a0),d0
		bsr PrintHex
		move.b (2,a0),d0
		bsr PrintHex
		move.b (3,a0),d0
		;bsr PrintHex	
		
PrintHex:
	pushall
		move.w d0,d2
		move.w d2,d1
		and.w #%11110000,d1
		ror.b #4,D1	
		bsr PrintHexChar
		
		move.w d2,d1
		and.w #%00001111,d1
		bsr PrintHexChar	
	popall
	rts
PrintHexChar:	
	move.w d1,d0
	and.l #$FF,d0
	cmp.b #9,d0
	ble PrintHexCharLessThan10
	add.w #'A'-10,d0
	jmp PrintChar
PrintHexCharLessThan10:		
	add.w #'0',d0
	jmp PrintChar
	
	
	
Monitor:
	moveM.l d0-d7/a0-a7,-(sp)

	move.l sp,a0

	
	move.w #'0',d5
	
ShowNextReg:
	move.w #'D',d0
	bsr PrintChar
	move.w d5,d0
	bsr PrintChar
	move.w #':',d0
	bsr PrintChar
	bsr ShowReg
	
	move.w #' ',d0
	bsr PrintChar
	bsr PrintChar
	bsr PrintChar
	
	add #8*4,a0
	
	move.w #'A',d0
	bsr PrintChar
	move.w d5,d0
	bsr PrintChar
	move.w #':',d0
	bsr PrintChar
	bsr ShowReg
	
	sub #8*4,a0
	add #4,a0
	
	bsr NewLine
	
	add #1,d5
	cmp #'8',d5
	bne ShowNextReg
	
	add #8*4,a0
	move.w #'P',d0
	bsr PrintChar
	move.w #'C',d0
	bsr PrintChar
	move.w #':',d0
	
	bsr PrintChar
	bsr ShowReg
	bsr NewLine	


	moveM.l (sp)+,d0-d7/a0-a7

	rts

;usage:
;	lea Address,a0
; 	moveq.l #6,d0
;	jsr Monitor_MemDumpDirect
Monitor_MemDumpDirect:
	moveM.l d0-d7/a0-a7,-(sp)
		Movea.l a0,a1
		Move.w d0,d4
		jsr Monitor_MemDumpDraw
	moveM.l (sp)+,d0-d7/a0-a7
	rts
	
;usage:
	;jsr Monitor_MemDump
	;dc.l $00000000
	;dc.w $6
Monitor_MemDump:
	moveM.l d0-d7/a0-a7,-(sp)
	bsr NewLine
	Move.l (64,sp),a0
	;jsr Monitor
	Movea.l (a0),a1
	Move.w (4,a0),d4
	
	
	jsr Monitor_MemDumpDraw
	
	moveM.l (sp)+,d0-d7/a0-a7
	add.l #6,(sp)
	rts
	
Monitor_MemDumpDraw:	
	move.l a1,d0
	rol.l #8,d0
	bsr PrintHex
	rol.l #8,d0
	bsr PrintHex
	rol.l #8,d0
	bsr PrintHex
	rol.l #8,d0
	bsr PrintHex
	
	
	Move.b #':',d0
	bsr PrintChar
	bsr NewLine
MemDump_NextLine:
	move.l #7,d3
MemDump_NextByte:
	move.b (a1)+,d0
	bsr PrintHex
	Move.b #' ',d0
	bsr PrintChar
	dbra d3,MemDump_NextByte
	;jsr Monitor
	subq.l #8,a1
	move.w #7,d3
MemDump_NextChar:
	move.b (a1)+,d0
	cmp #32,d0
	blt MemDump_BadChar
	cmp #128,d0
	bgt MemDump_BadChar
	bra MemDump_OkChar
MemDump_BadChar:
	Move.b #'.',d0
MemDump_OkChar:
	bsr PrintChar
	dbra d3,MemDump_NextChar
	bsr NewLine
	
	sub.b #1,d4
	bne MemDump_NextLine
	
	
	rts
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	
	
Monitor_PushedRegister:
	
	moveM.l d0-d7/a0-a7,-(sp)
	Move.b #'*',d0
	bsr PrintChar
	move.l sp,a0
	add.l #64+4,a0
	bsr ShowReg
	Move.b #'*',d0
	bsr PrintChar
	moveM.l (sp)+,d0-d7/a0-a7
	move.l (sp)+,(sp)			;Write over the pushed register with the return value
	rts