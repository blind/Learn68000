;pixels are stored in words clusers, eg 1234,ABCD = pixel 1234, 
;  then bitplane , so ABCD= second bitplane of pixels 1234

GetScreenPos: ; d1=x d2=y
	moveM.l d0-d7/a0-a5,-(sp)
	and.l #$FF,d1
	and.l #$FF,d2
		move.l ScreenBase,a6 ;Get screen pointer into a6
		move.l d1,d3	
		and.l #%11111110,d1
		and.l #%00000001,d3	 ;shift along 1 byte each 4 pixel pairs
		rol.l #2,d1			 ;4 Bitplane words consecutive in memory
		add.l d1,a6
		add.l d3,a6
		
		mulu #160,d2		 ;160 bytes per Y line
		add.l d2,a6
	moveM.l (sp)+,d0-d7/a0-a5
	rts
	
GetNextLine:	
	add.l #160,a6			;Move down a line
	rts
	
waitVBlank:
	move.w       #$25,-(sp)	;use XBIOS to wait for VBlank
	trap         #14
	addq.l       #2,sp
	rts


; waitVBlank:
	; move.l $462,d0			; VBI counter
; waitVBlank2:	
	; cmp.l $462,d0
	; beq waitVBlank2			;Wait until vblank count changes
	; rts

	
	
ScreenINIT:	
	move.b #$00,$ff8260		;Screen Mode: 00=320x200 4 planes
	
    move.l #screen_mem,d0  	;Move address to screen mem to d0
    add.l #$ff,d0      		;Add 255 d0 address
    clr.b d0           		;Clear lowest byte in address
    move.l d0,ScreenBase	;Save screen start
	
    lsr.w #8,d0       		;we need to convert $00ABCD?? into $00AB00CD
    move.l d0,$ff8200		;store the resulting 16 bits into the screen start register
							;&FF8201 = High byte
							;&FF8203 = Mid  byte
							;Low byte cannot be specified
			;-RGB
	move.w #$0007,$ff8240 	;Color 0
	move.w #$0770,$ff8242 	;Color 1
	move.w #$0077,$ff8244 	;Color 2
	move.w #$0700,$ff8246 	;Color 3
	move.w #$0770,$ff825E 	;Color 15
	rts