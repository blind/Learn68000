Cursor_X equ UserRam
Cursor_Y equ UserRam+1
	ifd BuildX68
ScrWid256 equ 1
	endif
	include "\SrcALL\BasicMacros.asm"
	include "\SrcALL\V1_Header.asm"
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	
;Example 1
	move.l #$69,d0			;Load hex 69 into A
	jsr monitor 			;Show registers to screen
	jmp *					;Infinite Loop
	
	
;Example 2	
	; move.l #$69,d0			;Load D0 with Hex $69
	; move.l #69,d1			;Load D1 with Decimal 69
	; move.l (69),d2			;Load D2 from memory address 000069 - Won't work on X68000!
	; jsr monitor				;Show the monitor
	; jmp *					;Infinite Loop


;Example 3
	;move.l #0,d0			;Clear D0
	;move.l d0,d1			;Clear D1
	;move.l d0,d2			;Clear D2
	
	; move.l #$69696969,d0	;Set D0 to a 32bit number
	; move.w d0,d1			;Copy 16 bits of D0 to D1
	; move.b d0,d2			;Copy 8 bits of D0 to D1
	; move.l #$77777777,d3	;Load D3 with Hex $77777777
	; move d0,d3				;Copy D0 to D3 without specifying length
	
	; jsr monitor				;Show the monitor
	; jmp *					;Infinite Loop

;Example 4
	 ; clr.l d1				;Set D1 to 0
	 ; moveA.l #$69696969,a0	;Load A0 with Hex $69695959
	 ; MoveQ.l #$01,d1		;Move Quick Long -128 to 127
	 ; jsr monitor			;Show the monitor
	 ; jmp *					;Infinite Loop
	
;Example 5

	  ; move.l #$15,d0		;Set D0 to Hex 15
	  ; jsr MonitorD0			;Show the monitor
	  
	  ; add.l #3,d0			;Add 3
	  ; jsr MonitorD0			;Show the monitor
	  ; sub.l #3,d0			;Suptract 3
	  ; jsr MonitorD0			;Show the monitor
	  
	  ; addI.l #1,d0			;Add 3 - Technically we should use AddI with #
	  ; jsr MonitorD0			;Show the monitor
	  ; subI.l #1,d0			;Sub 3 - Technically we should use SubI with #
	  ; jsr MonitorD0			;Show the monitor
	  
	  ; addq.l #7,d0			;0-7 only - faster
	  ; jsr MonitorD0			;Show the monitor
	  ; subq.l #7,d0			;0-7 only - faster
	  ; jsr MonitorD0			;Show the monitor
	  
	  ; jmp *					;Infinite Loop
	

;Example 6	
	; lea UserRam+100,a0			;Show some of our memory to screen
 	; moveq.l #1,d0				;
	; jsr Monitor_MemDumpDirect	;
	
	; LEA UserRam+100,a0			;Load 3 bytes into A0,A1,A2
	; LEA UserRam+101,a1			;
	; LEA UserRam+102,a2			;
	
	; move.b #$11,d0				;load $11 into D0
	; move.b d0,(a0)				;Save D0 to address in A0
	; move.b #$22,(a1)			;Save $22 directly to address in A1
		 
	; move.b #$33,d2				;Load $33 into D2
	; add.b (a0),d2				;add value from address in A0
	; add.b (a1),d2				;add value from address in A1
	; move.b d2,(a2)				;Save A2 to address in A2
	
	; lea UserRam+100,a0			;Show the same memory after the
 	; moveq.l #1,d0				;Commands have been performed
	; jsr Monitor_MemDumpDirect	;
	
	; jmp *						;Infinite Loop
	
	
MonitorD0:
	 move.l d0,-(sp)
	 jsr Monitor_PushedRegister
	 jsr NewLine
	 rts
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	

	include "\SrcALL\V1_VdpMemory.asm"
	
	include "\SrcALL\V1_BitmapMemory.asm"
	include "\SrcAll\V1_Palette.asm"
	
	include "\SrcALL\V1_Functions.asm"
	include "\SrcALL\Multiplatform_Monitor.asm"
	
	include "\SrcALL\BasicFunctions.asm"	
	include "\SrcALL\V1_DataArea.asm"
		
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;				Data Area
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
	ifnd BuildNEO			;NeoGeo Doesn't use font or Tiles (they are in the fixmap)
Font:
		incbin "\ResALL\Font96.FNT"
	endif


	even
	include "\SrcALL\V1_RamArea.asm"
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;				Ram Area - May not be possible on all systems!!!
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ifnd UserRam
UserRam:
	ds $1000
	endif
	
	
	
	include "\SrcALL\V1_Footer.asm"