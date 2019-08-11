
DefineTiles:				;Not possible on NEO - must define in FIX ROM
	rts


	;move.l #3,d0	;SX
	;move.l #3,d1	;SY
	;move.l #6,d2	;WID
	;move.l #6,d3	;HEI
	;move.l #256,d4	;TileStart

	FillAreaWithTiles:		;Fill an area of the FIX tilemap with tiles
							;d0=SX d1=SY	d2=wid d3=hei d4=TileStartNum
	moveM.l d0-d7/a0-a7,-(sp)
		clr.l d6
		clr.l d7
			;	PTTT  - Palette / Tile	
		add.w #$1800,d4			;We're starting at tile $1800
								;   so load FIX into offset="0x010000"
						
		subq.l #1,d3			;Height -1
		subq.l #1,d2			;Width  -1
NextTileLine:
		moveM.l D2,-(sp)		;Back up Width
		
			move.L  #$7000,d5	;Fixmap starts at $7000
			clr.L 	d7
			move.B 	d0,D7		;Xpos 
			rol.L 	#5,D7		;*32 - memory is ordered Cols/Rows 
			add.L 	D7,D5		;      32 cols per X line
			
			clr.L 	d7
			move.b 	d1,D7		;Ypos
			addq.l 	#2,d7		;NEO doesn't recommend using top 2 columns
			add.L 	D7,D5
NextTileb:
			move.w d5,$3C0000 		;address
			move.w d4,$3C0002		;tile data
				
			add.l #32,d5			;Increase X by adding 32 to addr
			addq.w #1,d4			;Increase Tile
			
			dbra d2,NextTileb
			add.w #1,d1				;Increase Y

			move.l (sp)+,d2			;Restore Width
		dbra d3,NextTileLine
	moveM.l (sp)+,d0-d7/a0-a7
	rts
	
	
	
	ifd VblankCount
waitVBlank:
	move.b VblankCount,d1		; 	VBI counter
waitVBlank2:	
	jsr KickWatchdog
	cmp.b VblankCount,d1
	beq waitVBlank2
	rts
	endif

    