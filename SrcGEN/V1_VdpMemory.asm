
DefineTiles:						;Copy D1 bytes of data from A0 to VDP memory D2 

	jsr prepareVram					;Calculate the memory location we want to write
DefineTilesAgain:						; the tile pattern definitions to
		move.l (a0)+,d0				
		move.l d0,(VDP_data)		;Send the tile data to the VDP
		dbra d1,DefineTilesAgain
		
	rts
			
prepareVram:							;To select a memory location D2 we need to calculate 
										;the command byte... depending on the memory location
	moveM.l d0-d7/a0-a7,-(sp)			;$7FFF0003 = Vram $FFFF.... $40000000=Vram $0000
		move.l d2,d0
		and.w #%1100000000000000,d0		;Shift the top two bits to the far right 
		rol.w #2,d0
		
		and.l #%0011111111111111,d2	    ; shift all the other bits left two bytes
		rol.l #8,d2		
		rol.l #8,d2
		
		or.l d0,d2						
		or.l #$40000000,d2				;Set the second bit from the top to 1
										;#%01000000 00000000 00000000 00000000
		move.l d2,(VDP_ctrl)
	moveM.l (sp)+,d0-d7/a0-a7
	rts

	
	;move.l #3,d0	;SX
	;move.l #3,d1	;SY
	
	;move.l #6,d2	;WID
	;move.l #6,d3	;HEI
	
	;move.l #256,d4	;TileStart
	
FillAreaWithTiles:					;Set area (d0,d1) Wid:d2 Hei:D3
	moveM.l d0-d7/a0-a7,-(sp)
		clr.l d6
		clr.l d7
		
		subq.l #1,d3					;Reduce our counters by 1 for dbra
		subq.l #1,d2
		
NextTileLine:
		move.l d2,-(sp)					;Wid
			Move.L  #$40000003,d5		;$C000 offset + Vram command
			Move.L #0,d7
			Move.B d1,D7				
			
			rol.L #8,D7					; Calculate Ypos
			rol.L #8,D7
			rol.L #7,D7
			add.L D7,D5
			
			Move.B d0,D7				;Calculate Xpos
			rol.L #8,D7
			rol.L #8,D7
			rol.L #1,D7
			add.L D7,D5
		
			MOVE.L	D5,(VDP_ctrl)		; C00004 Get VRAM address
NextTileb:		
			MOVE.W	D4,(VDP_data)		; C00000 Select tile for mem loc
			addq.w #1,d4				;Increase Tilenum
			dbra d2,NextTileb
			add.w #1,d1					;Move down a line
		move.l (sp)+,d2
		dbra d3,NextTileLine			;Do next line
	moveM.l (sp)+,d0-d7/a0-a7
	rts
	
	
	
	
	
waitVBlank:							;Bit 3 defines if we're in Vblank
	move.w VDP_ctrl,d0
	and.w #%0000000000001000,d0		;See if vblank is running
	bne waitVBlank					;wait until it is
		
waitVBlank2:
	move.w VDP_ctrl,d0
	and.w #%0000000000001000,d0		;See if vblank is running
	beq waitVBlank2					;wait until it isnt
	rts

	
	
	
ScreenINIT:	
	LEA	VDPSettings,A5			;initialize registers
	MOVE.W	(VDP_ctrl),D0		;C00004 read VDP status (interrupt acknowledge?)

	move.l #$00008000,d5		;VDP Reg command
	MOVEQ.l	#24-1,D1			;length of video initialization block
NextInitByte:
	MOVE.B	(A5)+,D5			;get next video control byte
	MOVE.W	D5,(VDP_ctrl)		;C00004 send write register command to VDP
	ADD.W	#$00000100,D5		;point to next VDP register
	DBRA	D1,NextInitByte		;loop for rest of block


	;Define palette
	move.l #$C0000000,d0					;Color 0
	move.l d0,VDP_Ctrl
	;        ----BBB-GGG-RRR-
	move.w #%0000011000000000,VDP_data
	
	move.l #$C0020000,d0					;Color 1
	move.l d0,VDP_Ctrl
	move.w #%0000000011101110,VDP_data
	
	move.l #$C0040000,d0					;Color 2
	move.l d0,VDP_Ctrl
	move.w #%0000111011100000,VDP_data
	
	move.l #$C0060000,d0					;Color 3
	move.l d0,VDP_Ctrl
	move.w #%0000000000001110,VDP_data
	
	move.l #$C01E0000,d0					;Color 15
	move.l d0,VDP_Ctrl
	move.w #%0000000011101110,VDP_data
	
	MOVE.W	#$8144,(VDP_Ctrl)				; C00004 reg 1 = 0x44 unblank display
	
	jmp FontINIT
	
	
	
	
SetSprite:

		
		move.l d2,-(sp)
			move.l d0,d2
			rol.l #3,d2					;4 bytes per Sprite
			add.l #$D800,d2				;Base Sprite Address
			jsr prepareVram
		move.l (sp)+,d2
		
		move.w d2,(VDP_data)			; ------VV VVVVVVVV - Vpos
		move.w d4,(VDP_data)			; ----WWHH -LLLLLLL - Width, Height, Link (to next sprite)
		move.w d3,(VDP_data)			; PCCVHNNN NNNNNNNN - Priority, Color palette , Vflip, Hflip, tile Number
		move.w d1,(VDP_data)			; -------H HHHHHHHH - Hpos
	rts	
	
	
	EVEN
VDPSettings:
		DC.B $04 ; 0 mode register 1											---H-1M-
		DC.B $04 ; 1 mode register 2											-DVdP---
		DC.B $30 ; 2 name table base for scroll A (A=top 3 bits)				--AAA--- = $C000
		DC.B $3C ; 3 name table base for window (A=top 4 bits / 5 in H40 Mode)	--AAAAA- = $F000
		DC.B $07 ; 4 name table base for scroll B (A=top 3 bits)				-----AAA = $E000
		DC.B $6C ; 5 sprite attribute table base (A=top 7 bits / 6 in H40)		-AAAAAAA = $D800
		DC.B $00 ; 6 unused register											--------
		DC.B $00 ; 7 background color (P=Palette C=Color)						--PPCCCC
		DC.B $00 ; 8 unused register											--------
		DC.B $00 ; 9 unused register											--------
		DC.B $FF ;10 H interrupt register (L=Number of lines)					LLLLLLLL
		DC.B $00 ;11 mode register 3											----IVHL
		DC.B $81 ;12 mode register 4 (C bits both1 = H40 Cell)					C---SIIC
		DC.B $37 ;13 H scroll table base (A=Top 6 bits)							--AAAAAA = $FC00
		DC.B $00 ;14 unused register											--------
		DC.B $02 ;15 auto increment (After each Read/Write)						NNNNNNNN
		DC.B $01 ;16 scroll size (Horiz & Vert size of ScrollA & B)				--VV--HH = 64x32 tiles
		DC.B $00 ;17 window H position (D=Direction C=Cells)					D--CCCCC
		DC.B $00 ;18 window V position (D=Direction C=Cells)					D--CCCCC
		DC.B $FF ;19 DMA length count low										LLLLLLLL
		DC.B $FF ;20 DMA length count high										HHHHHHHH
		DC.B $00 ;21 DMA source address low										LLLLLLLL
		DC.B $00 ;22 DMA source address mid										MMMMMMMM
		DC.B $80 ;23 DMA source address high (C=CMD)							CCHHHHHH


	even