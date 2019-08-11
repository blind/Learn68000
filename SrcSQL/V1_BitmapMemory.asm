GetScreenPos: ; d1=x d2=y
	moveM.l d0-d7/a0-a5,-(sp)
		and.l #$FF,d1
		and.l #$FF,d2

		ifd ScrWid256
			add.l #4*8,d2		;Move Y down 32 lines to simulate
		endif					;	 a 256*192 screen 
		
		rol.l #1,d1				;Multiply X*2 (2 bytes per 4/8 pixels)
		rol.l #7,d2				;Multiply Y*128
		
		move.l #$00020000,a6	;Screen starts at $20000
		add.l d2,a6
		add.l d1,a6
	moveM.l (sp)+,d0-d7/a0-a5
	rts
	
GetNextLine:	
	add.l #128,a6				;Add 128 to move down a line
	rts
	
	
waitVBlank:
	move.b #%11111111,$18021	;Clear interrupt flags
waitVBlankAgain
	move.b $18021,d0			;See if interrupt has occurred
	tst.b d0
	beq waitVBlankAgain
	rts
	
	