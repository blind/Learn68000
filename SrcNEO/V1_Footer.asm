	even
PLAYER_START:					;Player pressed start on title
	move.b	d0,REG_DIPSW		; kick the watchdog
	rts
DEMO_END:						;Demo mode ended
	rts
COIN_SOUND:						; Send a sound code
	rts

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;								Vblank interrupt
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
VBlank:
	btst	#7,BIOS_SYSTEM_MODE	; check if the BIOS wants to run its vblank
	bne		gamevbl
	jmp		SYSTEM_INT1			; run BIOS vblank
gamevbl:						; run the game's vblank
	movem.l d0-d7/a0-a6,-(sp)	; save registers
	move.w	#4,LSPC_IRQ_ACK		; acknowledge the vblank interrupt
	move.b	d0,REG_DIPSW		; kick the watchdog

	ifd VblankCount
		addq.b #1,VblankCount	;Added for Grime 68000
	endif
	
endvbl:
	jsr		SYSTEM_IO			; "Call SYSTEM_IO every 1/60 second."
	jsr		MESS_OUT			; Puzzle Bobble calls MESS_OUT just after SYSTEM_IO
	move.b	#0,flag_VBlank		; clear vblank flag so waitVBlank knows to stop
	movem.l (sp)+,d0-d7/a0-a6	; restore registers
	rte

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
IRQ2:
	move.w	#2,LSPC_IRQ_ACK		; ack. interrupt #2 (HBlank)
	move.b	d0,REG_DIPSW		; kick watchdog
	rte
IRQ3:
	move.w  #1,LSPC_IRQ_ACK		; acknowledge interrupt 3
	move.b	d0,REG_DIPSW		; kick watchdog
	rte