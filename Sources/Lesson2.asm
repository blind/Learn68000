Cursor_X equ UserRam
Cursor_Y equ UserRam+1
	ifd BuildX68
ScrWid256 equ 1
	endif
	include "\SrcALL\BasicMacros.asm"
	include "\SrcALL\V1_Header.asm"
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	

	
	lea TestData,a0
	move.l #$00FF00F0,a1
	
	move.l #$1F,d0
FillTestData:	
	move.b (a0)+,(a1)+
	dbra d0,FillTestData
	
	
	jsr Monitor_MemDump
	dc.l $00FF00F0
	dc.w $4
	jsr newline
	
	clr.l d0
	move.l #$00FF0100,a1
	move.l #$00000001,d1
	
;Example 1 - Immmediate
	; move.l #$12345678,d0
	; jsr monitor 
	; jmp *

;Example 2 - Absolute
	 ; Move.l $00FF0100,d0	;If you use L or W the address must be EVEN 
	 ; jsr monitor 
	 ; jmp *
	
;Example 3 - Data Direct
	 ; move.L D1,D0
	 ; jsr monitor 
	 ; jmp *
	
;Example 4 - Address Direct
	; move.l a1,d0
	; jsr monitor 
	; jmp *

;Example 5 - Address Register Indirect
	 ; move.W (a1),d0		;If you use L or W the address must be EVEN 
	 ; jsr monitor 
	 ; jmp *
		
		
;Example 6 - Address register Indirect with PostIncrement
	 ; Move.l (A1)+,D0

	 ; jsr monitor 
	 ; jmp *
	
;Example 7 - Address register with Predecriment
	  ; Move.W -(A1),D0
	 
	 ; Move.L #UserRam+$200,a2
	 ; Move.L #UserRam+$300,a7
	  ; Move.B -(A2),D0				;A2    will be decreased by 1 byte
	  ; Move.B -(A7),D0				;A7/SP will be decremented by TWO BYTES - A7 is special
	  ; Move.l a7,a3
	  ; jsr monitor 
	  ; jmp *
	
;Example 8 - Address register indirect, with 16-bit displacement 
	; Move.B (2,A1),D0
	; jsr monitor 
	; jmp *
	
;Example 9 - Address register indirect with indexing and 8-bit displacement
	; Move.B (A1,D1),D0
	; jsr monitor 
	; jmp *
	
;Example 10 - Program counter relative addressing with a 16-bit offset
	; Move.W (PCTestData,pc),D0
	; Move.W (8,pc),D1
	; jsr monitor 
	; jmp * 
; PCTestData:
		; dc.b $68,$69,$70
	
;Example 11 - Program counter relative addressing with an 8-bit offset plus an index register. 
	; Move.B D0,(PCTestData,pc,d1)
	; Move.B (8,pc,d1),D2
	; jsr monitor 
	; jmp * 
; PCTestData:
		; dc.b $68,$69,$70
		; even
	
TestData:	
	dc.b $00,$01,$02,$03,$04,$05,$06,$07,$08,$09,$0A,$0B,$0C,$0D,$0E,$0F
	dc.b $F0,$F1,$F2,$F3,$F4,$F5,$F6,$F7,$F8,$F9,$FA,$FB,$FC,$FD,$FE,$FF
	
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