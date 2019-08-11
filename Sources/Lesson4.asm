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
	
	; Move.l #$00FF0100,a7			;Set our stack pointer to a fixed memory address - This is designed for the Genesis

	; jsr Monitor_MemDump				;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0
	
	; Move.w #$1234,-(sp)				;Push a word onto the stack (2 bytes)
	
	; jsr Monitor_MemDump				;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0

	
	; Move.L #$FFEEDDCC,-(sp)			;Push a Long onto the stack
	
	; jsr Monitor_MemDump				;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0

	; Move.B #$96,-(sp)				;Push a byte onto the stack
	; Move.B #$96,-(sp)				;Push a byte onto the stack
	
	; jsr Monitor_MemDump
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0
	
	
	; jsr newline 
	
	; Move.B (sp)+,d0					;Pop a byte off the stack
	; jsr MonitorD0
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0
	
	; Move.L (sp)+,d0					;Pop a Long off the stack - note
	; jsr MonitorD0					;We're popping off in a different order!
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0
	
	; Move.L (sp)+,d0					;Pop a Long off the stack
	; jsr MonitorD0
	; move.l a7,d0					;Show the stack pointer
	; jsr MonitorD0
	
	 ; jmp *					;Infloop
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 2
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; Move.l #$00FF0100,a7	;Set our stack pointer to a fixed memory address - This is designed for the Genesis

	; jsr Monitor_MemDump		;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0			;Show the stack pointer
	; jsr MonitorD0
	
	; jsr StackTest			;Call the StackTest
; ReturnPos:
	; jsr Monitor_MemDump		;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0			;Show the stack pointer
	; jsr MonitorD0
	; jmp *					;Infloop
		 
; StackTest:
	; jsr Monitor_MemDump		;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
	
	; move.l a7,d0			;Show the stack pointer
	; jsr MonitorD0
	
	; lea ReturnPos,a0		;Show the next line we're planning to run
	; move.l a0,d0
	; jsr MonitorD0
	; rts
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 3
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	 
	; Move.l #$00FF0100,a7		;Set our stack pointer to a fixed memory address - This is designed for the Genesis

	; move.w #$1234,d0			;Set some Word values into the registers
	; move.w #$ABCD,d1
	; move.w #$9876,d2
	
	; MoveM.W d0-d2,-(sp)			;Push registers d0-d2 onto the stack
	
		; jsr Monitor_MemDump		;Show the stack memory
		; dc.l $00FF00F0
		; dc.w $2
		
	; MoveM.W (sp)+,d0-d2			;Pop registers d0-d2 onto the stack
		
	; MoveM.W d0-d2,-(sp)			;Concecutive registers can be specified with a -
	; MoveM.W (sp)+,d0-d2
		
	; MoveM.W d0/d3/d5,-(sp)		;Unrelated registers can be specified with a /
	; MoveM.W (sp)+,d0/d3/d5
	
	; moveM.l d0-d7/a0-a7,-(sp)	;We can push ALL registers with this command
	; moveM.l (sp)+,d0-d7/a0-a7
	
	 ; jmp *					;Infloop
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 4
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	
	; Move.l #$00FF0100,a7 ;Set our stack pointer to a fixed memory address - This is designed for the Genesis
	
	; lea TestAddr,a0		;Load the Effective Address of TestAddr into A0
	; Move.l a0,d0		;LEA does not work with Data Registers
	; jsr MonitorD0		;show the address we loaded with LEA
	
	; pea TestAddr		;Push Effective TestAddress onto the stack
	
	; jsr Monitor_MemDump	;Show the stack memory
	; dc.l $00FF00F0
	; dc.w $2
; TestAddr:				;Just a test label to load
	; jmp *

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
;Example 5
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	;move.l #-64,d0
	
	; move.l #64,d0			;Set Do to +64
	; jsr MonitorD0			;Show D0
	; jsr NewLine
	; neg.l d0				;Negate D0
	; jsr MonitorD0			;Show D0
	
	; jsr NewLine
	
	
	; move.l #$3401,d0	
	; jsr MonitorD0
	; Mulu.W #$100,d0			;Unsigned Multiply
	; jsr MonitorD0
	; jsr NewLine
	
	; move.l #$-3401,d0	
	; jsr MonitorD0
	; Muls.W #$100,d0			;Signed Multiply
	; jsr MonitorD0
	; jsr NewLine
	
	
	; move.l #-$3401,d0		;We've used the wrong command, this won't work right
	; jsr MonitorD0			;We've used the wrong command, this won't work right
	; Mulu.W #$100,d0			;We've used the wrong command, this won't work right
	; jsr MonitorD0			;We've used the wrong command, this won't work right
	; jsr NewLine				;We've used the wrong command, this won't work right
	
	
	; move.l #$3401,d0	
	; jsr MonitorD0
	; Divu.W #$100,d0			;Unsigned devide 
	; jsr MonitorD0			;result is RRRRQQQQ 
	; jsr NewLine				 ;Q=Quotient (sucessful divides) R=Remainder 
		
	; move.l #-$3401,d0	
	; jsr MonitorD0
	; Divs.W #$100,d0			;Singned divide 
	; jsr MonitorD0			;result is RRRRQQQQ
	; jsr NewLine				 ;Q=Quotient (sucessful divides) R=Remainder 
	
	; ; move.l #-$3400,d0		;We've used the wrong command, this won't work right
	; ; jsr MonitorD0			;We've used the wrong command, this won't work right
	; ; Divu.W #$100,d0			;We've used the wrong command, this won't work right
	; ; jsr MonitorD0			;We've used the wrong command, this won't work right
	
	  jmp *
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	
;Example 7
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    


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
	
	
	
	include "\SrcALL\V1_Footer.asm"