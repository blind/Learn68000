Cursor_X equ UserRam
Cursor_Y equ UserRam+1
	ifd BuildX68
ScrWid256 equ 1
	endif
	include "\SrcALL\BasicMacros.asm"
	include "\SrcALL\V1_Header.asm"
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 1
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	 ; jsr monitor			;Call the monitor
	 ; move.l #$66666666,d0	;Load a number into d0
	 ; jmp skipto			;Jump to Skipto
	 ; move.l #$77777777,d0	;This will be skipped
; Skipto:
	 ; jsr monitor			;Show the monitor
	 ; jmp *					;Infloop
	
	;JMP/JSR Jump (full address specified in theory - Actually VASM optimizes this out!)
	;BRA/BSR Branch (shortended relative address)
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 2
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.l #0,d0
	 ; jsr MonitorD0		;call the monitorD0 subroutine
	 ; jsr AddTwo			;call the AddTwo subroutine
	 ; jsr MonitorD0		;call the monitorD0 subroutine
	 
	 ; lea A1Test,a1		;Load the label 'A1Test's address into A1
	 ; move.w (a1),d0		;Load a word from the address in A1 into D0
	 ; jsr MonitorD0		;call the monitorD0 subroutine
	 ; jmp * 				;Inf Loop
	 
; AddTwo:
	; addq #2,d0			;Add 2 to D0
	; rts					;Return to where we came!

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 3
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	 
; Symboltest equ $9876
	
	; move.w Symboltest,d0	;Load 'Symboltest' into d0
	; jsr MonitorD0			;call the monitorD0 subroutine
	; jmp * 					;Inf Loop
	 

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 4
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	; ; move.l #3,d0		
	; ; cmp.l #3,d0
	; ;bcs Jumped			;d0<#? - Branch Carry Set
	; ; bcc Jumped			;d0>=#? - Branch Carry Clear	
	; ; jmp *				;Infinite Loop
	

	

	; ; ;move.l #3,d0			
	; ; ;beq Jumped				;reg=0
	; ; ;bne Jumped				;reg!=0
	
	; ; move.l #1,d0						;-1=255 -128=128
	; ; move.b #-1,d0						;-1=255 -128=128
	; ; bpl Jumped				;A<128
	; ; bmi	Jumped				;A>=128
	
	; move.b #128,d0			
	; cmp.b #10,d0
	; ble Jumped				;d0<=#?	(signed)
	; ; ;blt Jumped				;d0<#? (signed)
	; ; ;bcs Jumped				;d0<#? (unsigned)
	
	
	; ; ;bge Jumped				;d0>=#?	(Signed)
	; ; ;bcc Jumped				;d0>=#? (unsigned)
	; jmp *					;Infinite Loop
; Jumped:
	; jsr monitor
	; jmp *					;Infinite Loop


;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 5
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.b #$FFFFFFFF,d0		;
	; move.b #0,d0		
	; cmp.b #0,d0			;Compare to #0 *** NOTE THIS IS NOT CMP.B ***
	; beq Jumped			;d0=#? - Branch if Equal
	; jmp *				;Infinite Loop
	
; Jumped:
	; jsr monitor
	; jmp *					;Infinite Loop

	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
;Example 6
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	move.l #$FFFFFFFF,d0	;Fill the top 2 bytes to junk
	move.w #5,d0			;Set D0 to 5 - DBRA works at WORD level
DbraTest:
	jsr MonitorD0			;Jump Service Routine
	dbra.l d0,DbraTest		;Decrement and Branch until below zero 
	
	lea EndedString,a3
	jsr PrintString
	jsr newline
	jsr MonitorD0			;Jump Service Routine (full address specified in theory - Actually VASM optimizes this out!)
	

	

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 7
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.l #4,d1
; CaseAgain
	; cmp.l #3,d1
	; beq Case3
	; cmp.l #2,d1
	; beq Case2
	; cmp.l #1,d1
	; beq Case1
	; cmp.l #0,d1
	; beq Case0
; CaseDone
	; subq.l #1,d1
	; jmp CaseAgain
	ds 1024			;The 6502 can only branch to an address 128 bytes away - the 68000 has no such problem!
; Case3:
	; move.b #"C",d0
	; jsr PrintChar
	; jmp CaseDone
; Case2:
	; move.b #"B",d0
	; jsr PrintChar
	; jmp CaseDone	
; Case1:
	; move.b #"A",d0
	; jsr PrintChar
	; jmp CaseDone
; Case0:
	; jmp *
	
	
	
	
	
	
	
	
MonitorD0:				;Monitor D0 subroutine
	 move.l d0,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 jsr NewLine		;Newline
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
EndedString:
	dc.b 'End!',255

	even
	include "\SrcALL\V1_RamArea.asm"
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;				Ram Area - May not be possible on all systems!!!
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	ifnd UserRam
UserRam:
	ds $1000
	endif
	

A1Test:
	dc.b $32,$23		;Two bytes at label A1Test
	
	
	include "\SrcALL\V1_Footer.asm"