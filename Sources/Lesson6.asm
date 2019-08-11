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

	; lea CCRString,a3	;String representing each bits meaning
	; jsr printstring 			;Show the string to the screen
	; jsr newline
	
	; ;	    ---XNZVC
	; or.b  #%11111111,ccr		;Set all the Flags
	; jsr MonitorBitsCCR
	
	; ;	    ---XNZVC
	; and.b #%00000000,ccr		;clear all the Flags
	; jsr MonitorBitsCCR
	
	; ;	    ---XNZVC
	; move.w #%0010100,ccr		;Set a combination of Flags
	; jsr MonitorBitsCCR
	
	; Jsr NewLine
	
	; move.w sr,d0				;Get the Status Register 
	; jsr MonitorBitsCCR
	; Jsr NewLine
	
	; jmp *
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 2
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	; lea CCRString,a3	;String representing each bits meaning
	; jsr printstring 			;Show the string to the screen
	; jsr newline
	
	; move.l  #%10111000,d0
	; jsr MonitorBitsCCR
	; move.w #8,d1
; RotateAgain:

	; ;	     ---XNZVC
	; move.w #%00010000,ccr		;Set the X flag

	; roxl.b #1,d0				;Rotate D0 right by #1 bit, 
								; ;fill the bottom bit with the eXtend reg, 
								; ;and put the bit pushed out the register into eXtend
	; jsr MonitorBitsCCR
	; dbra d1,RotateAgain			;DBcc does not affect the condition codes!
	
	; jmp *
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 3
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	; lea CCRString,a3			;String representing each bits meaning
	; jsr printstring 			;Show the string to the screen
	; jsr newline
	
	; move.l  #%10111001,d0
	; jsr MonitorBitsCCR
	; move.w #3,d1
; ASLAgain:
	; asl.b #1,d0					;Arithmatic shift D0 Left by #1 bit, 
								;Bottom bit will be 0
	; jsr MonitorBitsCCR
	; dbra d1,ASLAgain			;DBcc does not affect the condition codes!
	
	; move.w #3,d1
; ASRAgain:
	; asr.b #1,d0					;Arithmatic shift D0 Right by #1 bit, 
								;Top bit will be last top bit
	; jsr MonitorBitsCCR
	; dbra d1,ASRAgain			;DBcc does not affect the condition codes!
	
	; jsr newline
	; move.l  #%01110010,d0
	; jsr MonitorBitsCCR
	; move.w #3,d1
; ASRAgain2:
	; asr.b #1,d0					;Arithmatic shift D0 Right by #1 bit, 
								;Top bit will be last top bit
	; jsr MonitorBitsCCR
	; dbra d1,ASRAgain2			;DBcc does not affect the condition codes!
	
	
	
	; jmp *
	
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 4
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.l #$70000001,d0 ;We'll use D0 and D1 as a 64 bit number
	; move.l #$00000000,d1
	; move.w #8,d2
; ASRAgain2:	
	; jsr MonitorD1
	; jsr MonitorD0		;show the results
	; jsr NewLine
	
	; asl.l #1,d0			;Shift all the bits left - bottom bit 0, top bit into eXtend
	; roxl.l #1,d1		;Shift eXtend left into d1
	
	
	 ; dbra d2,ASRAgain2	;DBcc does not affect the condition codes!
	
	
	
	
	
	
	
	
	
	 ; jmp *
	
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 5
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	; move.l #$00000002,d0	;64 bit start value
	; move.l #$00000000,d1
	
	; move.l #$00000001,d3	;64 bit value to add/sub
	; move.l #$00000000,d4
	
	; move.w #5,d5	;Loop counter
; SubAgain:	
	; jsr MonitorD1
	; jsr MonitorD0	;show the results
	; jsr NewLine		
	
	; sub.l d3,d0		;Subtract the two parts of the pair
	; subx.l d4,d1
	
	; dbra d5,SubAgain
	
	; Jsr NewLine
	
	; move.w #5,d5	;reset the counter	
; AddAgain:	
	; jsr MonitorD1
	; jsr MonitorD0	;show the results
	; jsr NewLine		
	
	; add.l d3,d0		;add the two parts of the pair
	; addx.l d4,d1	
	
	; dbra d5,AddAgain
	; Jsr NewLine
	
	; jsr MonitorD1
	; jsr MonitorD0	;show the results
	; jsr NewLine		
	
	; ;	     ---XNZVC
	; ;move.w #%00000100,ccr		;if you want to use the Z flag in a BEQ 
								; ;set Z-flag first before two NEGX's
	; negx.l d0		
	; negx.l d1		;Negate the 64 bit pair
	
	; jsr MonitorD1
	; jsr MonitorD0	;show the results
	; jsr NewLine		
	
	; jmp *		

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 7
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

	; move.l #$000000F1,d0	;Test Byte
	;;move.l #$00000001,d0	;Test Byte
	
	; jsr MonitorD0	;show the results
	; jsr newline
	
	; ext.w d0		;Extend Byte to Word
	
	; jsr MonitorD0	;show the results
	; jsr newline
	
	; ext.l d0		;Extend Word to Long
	
	; jsr MonitorD0	;show the results
	; jsr newline
	
	; jmp *			;Infloop
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 8
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; Macro EightNoOps
		; nop
		; nop
		; nop
		; nop
		; nop
		; nop
		; nop
		; nop
	; endm

	; move.l #$FFFFFFFF,d0	
	; move.l #$00000000,d1
; Again:
	; move.b #0,d3
	; move.b #0,d6
	; jsr Locate	
	; exg d0,d1
	; jsr MonitorD1
	; jsr MonitorD0	;show the results
	; move.w #$F000,d7
; slowdown:
	; nop
	; nop
	; nop
	; nop
	; EightNoOps	;Macro for 8 Nops
	; EightNoOps	;Macro for 8 Nops
	; EightNoOps	;Macro for 8 Nops
	; EightNoOps	;Macro for 8 Nops
	; dbra d7,slowdown

	; jmp Again
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 9
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;	

TestSym equ 1

	ifnd TestSym 
		move.l #$88888888,d0
	else
		move.l #$55555555,d0
	endif
	
	jsr MonitorD0	;show the results
	
	jmp *
	
	
	
	
	
	
	
	
	
	
	
	
	
	
CCRString: dc.b '---XNZVC D0------',255

	
	
	
MonitorBitsCCR:	
	move.w SR,d7
	moveM.l d0-d7/a0-a7,-(sp)
	jsr MonitorBits	
	moveM.l d0,-(sp)
		move.b #' ',d0
		jsr printchar
	moveM.l (sp)+,d0
	jsr MonitorBitsD0
	jsr newline
	moveM.l (sp)+,d0-d7/a0-a7
	move.w d7,ccr
	rts
MonitorBitsD3:	
	move.b d3,d7	
	jmp MonitorBits
MonitorBitsD2:	
	move.b d2,d7	
	jmp MonitorBits
MonitorBitsD1:	
	move.b d1,d7	
	jmp MonitorBits
MonitorBitsD0:	
	move.b d0,d7
MonitorBits:
	moveM.l d0-d7/a0-a7,-(sp)
	move.l #7,d1
	
MonitorBitsAgain:
	rol.b #1,d7
	bcs MonitorBitsOne
	move.b #'0',d0
	jmp MonitorBitsDone
MonitorBitsOne:
	move.b #'1',d0
MonitorBitsDone:	
	jsr PrintChar
	dbra d1,MonitorBitsAgain
	moveM.l (sp)+,d0-d7/a0-a7
	
	rts
	
MonitorD0:				;Monitor D0 subroutine
	 move.l d0,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 
	 rts	
MonitorD1:				;Monitor D0 subroutine
	 move.l d1,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 
	 rts
MonitorD2:				;Monitor D0 subroutine
	 move.l d2,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 
	 rts
MonitorD3:				;Monitor D0 subroutine
	 move.l d3,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 
	 rts
MonitorD4:				;Monitor D0 subroutine
	 move.l d4,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 
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