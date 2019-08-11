ShowTile:	;d0=Tilenum, d1=X d4=Ypos	

	
	ifd BuildGEN
	moveM.l d0-d7/a0-a7,-(sp)
		
		clr.l d6
		clr.l d7
		
		add.l #256,d0	;TileStart
	
		;move.l d4,-(sp)
		Move.L  #$40000003,d5
		Move.L #0,d7
		Move.B d4,D7	;Y
		ifd ScrWid256
			add.b #2,d7
		endif
		rol.L #8,D7
		rol.L #8,D7
		rol.L #7,D7
			
		add.L D7,D5
			
		Move.B d1,D7	;X
		ifd ScrWid256
			add.b #4,d7
		endif
		rol.L #8,D7
		rol.L #8,D7
		rol.L #1,D7
		add.L D7,D5
		;move.l (sp)+,d4	
		MOVE.L	D5,(VDP_ctrl)			; C00004 write next character to VDP
		MOVE.W	D0,(VDP_data)			; C00000 store next word of name data
	moveM.l (sp)+,d0-d7/a0-a7
	endif
	
	
	
	ifd BuildNEO
	moveM.l d0-d7/a0-a7,-(sp)
		ifd ScrWid256
				add.b #2,d4
				add.b #4,d1
		endif
		clr.l d6
		clr.l d7
		add.w #$1800+256,d0	;Tile Num
		
		Move.L  #$7000,d5
		Move.L 	#0,d7
		Move.B 	d1,D7			;Xpos
		rol.L 	#5,D7			;x32
		add.L 	D7,D5		
		move.L 	#0,d7
		Move.B 	d4,D7			;Ypos
		add 	#2,d7				;NEO doesn't recommend using top 2 columns
		add.L 	D7,D5
		
		move.w d5,$3C0000 		;address
		move.w d0,$3C0002		;tile data
			
	moveM.l (sp)+,d0-d7/a0-a7
	endif
	
	
	
;BitmapMode equ 1










	;d0=Tilenum, d1=X d4=Ypos	
	ifd BuildAST
	pushall
		;move.l d1,-(sp)
		move.l d0,-(sp)
			move.l d4,d2
			and.l #$FF,d2
			and.l #$FF,d1
			rol.l #3,d2
			rol.l #2,d1
			;move.b #2,d1	;x
			;move.b #10,d2	;y
			ifd ScrWid256
				add.b #16,d1
			endif
			jsr GetScreenPos
		move.l (sp)+,d0
		;move.l (sp)+,d1
	;	eor.l #%00000001,d1			;rightmost bit of xpos
		;and.l #%00000001,d1			;rightmost bit of xpos;
		;add.l d1,a6		;Shift along by 1 
		;addq.l #1,a6
		
		
		move.l #7,d2		;Number of lines to draw
		
		and.l #$FF,d0
		rol.l #6,d0
		
		lea Bitmap,a0
		add.l d0,a0
BmpNextLine:			
		;move.l #4-1,d1				;Width of image
		move.l a6,-(sp)
BmpNextPixel:
			;move.b (a0),d0
			
			move.b (a0)+,(a6)+				;AST Format
			addq.l #1,a6		;Exporter works in words not bytes
			addq.l #1,a0		;Exporter works in words not bytes
			move.b (a0)+,(a6)+				;AST Format
			addq.l #1,a6		;Exporter works in words not bytes
			addq.l #1,a0		;Exporter works in words not bytes
			move.b (a0)+,(a6)+				;AST Format
			addq.l #1,a6		;Exporter works in words not bytes
			addq.l #1,a0		;Exporter works in words not bytes
			move.b (a0)+,(a6)+				;AST Format
			addq.l #1,a6		;Exporter works in words not bytes
			addq.l #1,a0		;Exporter works in words not bytes
			

		
		;dbra d1,BmpNextPixel
		move.l (sp)+,a6
		jsr GetNextLine
		;addq.l #4,a0		;Exporter works in words not bytes
		dbra d2,BmpNextLine
	popall
	endif



	
	ifd BuildAMI
		
	pushall
		move.l d0,-(sp)
			move.l d4,d2
			and.l #$FF,d2
			and.l #$FF,d1
			rol.l #3,d2
			;rol.l #3,d1
			;move.b #2,d1	;x
			;move.b #10,d2	;y
			ifd ScrWid256
			add.b #4,d1
			endif
			jsr GetScreenPos
		move.l (sp)+,d0
		
		
		move.l #8-1,d2
		
			
		and.l #$FF,d0
		rol.l #5,d0
		
		lea Bitmap,a0
		add.l d0,a0
		
		
BmpNextLine:			
		move.l #4-1,d1				;Width of image
		move.l a6,-(sp)
BmpNextPixel:
		move.b (a0),d0
		
		move.b (a0)+,(a6)		;Read in word chunks!
		move.b (a0)+,(40*200*1,a6)
		move.b (a0)+,(40*200*2,a6)	;4 bitplanes
		move.b (a0)+,(40*200*3,a6)
		
		addq.l #1,a6
		subq.l #3,d1
		dbra d1,BmpNextPixel
		move.l (sp)+,a6
		jsr GetNextLine
		ifd BuildAST
			addq.l #4,a0		;Exporter works in words not bytes
		endif
		dbra d2,BmpNextLine
		
		;jsr Monitor
		;jsr NewLine
	popall
	endif



	
	ifd BuildX68
	;d0=Tilenum, d1=X d4=Ypos	
	pushall
		move.l d0,-(sp)
			move.l d4,d2
			
			ifd ScrWid256
				ifnd TallTile
					add.b #3,d2
				endif
			endif
			and.l #$FF,d2
			and.l #$FF,d1
			ifd TallTile
				
				rol.l #1,d2		;y
				move.l d2,d0
				rol.l #2,d2		;y
				add.l d2,d0
				move.l d0,d2
			else
				rol.l #3,d2		;y
			endif
			
			rol.l #3,d1		;x
			jsr GetScreenPos
		move.l (sp)+,d0
		
		and.l #$FF,d0
		rol.l #5,d0
		
		lea Bitmap,a0
		add.l d0,a0
		
		ifd TallTile
			move.l #9,d2			;Line count
		else
			move.l #7,d2			;Line count
		endif
		
	BmpNextLine:			
		move.l #4-1,d1				;Width of image
		move.l a6,-(sp)
		ifd TallTile
			cmp.b #2,d2
			beq TileTallLine
			cmp.b #5,d2
			beq TileTallLine
			bra BmpNextPixel
TileTallLine
			subq.l #4,a0
		endif
		
	BmpNextPixel:
			move.b (a0),d0
			
			ror #4,d0
			move.w d0,(a6)+
			move.b (a0)+,d0
			move.w d0,(a6)+
		
		dbra d1,BmpNextPixel
		move.l (sp)+,a6
		jsr GetNextLine
		dbra d2,BmpNextLine
	popall
	endif
	
	rts