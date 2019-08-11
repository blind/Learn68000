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
	
	; move.b #%10101010,d0 ;Set test values
	; move.b #%10101010,d1
	; move.b #%10101010,d2
	; move.b #%10101010,d3
	
	; jsr MonitorBitsD0	;show the results
	; jsr MonitorBitsD1
	; jsr MonitorBitsD2
	; jsr MonitorBitsD3
	; jsr newline
	
	; and.b #%11110000,d0	;Keep only the top 4 bits 
	; or.b  #%11110000,d1 ;Set the top 4 bits 
	; eor.b #%11110000,d2 ;Flip the top 4 bits
	; not.b d3 			;Invert all the bits
	
	; jsr MonitorBitsD0	;show the results
	; jsr MonitorBitsD1
	; jsr MonitorBitsD2
	; jsr MonitorBitsD3
	; jsr newline
	
	; jmp *					;Infloop

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 2
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.l #$80808080,d1  ;Set test values
	; move.l #$80808080,d2  ; so we can see the results 
	; move.l #$80808080,d3
	; move.l #$80808080,d4
	; move.l #10,d0	;Load a test value into d0
	; cmp.b #10,d0	;Do a compare
	; jsr scctest		;Show the results!
	
	; move.l #10,d0	;Load a test value into d0
	; cmp.b #20,d0	;Do a compare
	; jsr scctest		;Show the results!
	
	; jmp *			;Infloop
	
; scctest:
	; seq d1			;Set D1 to 255 if equal
	; sne d2			;Set D2 to 255 if not equal
	; scs d3			;Set D3 to 255 if carry set
	; scc d4			;Set D4 to 255 if carry clear
	; jsr MonitorD1	;show the results
	; jsr MonitorD2
	; jsr MonitorD3
	; jsr MonitorD4
	; jsr newline
	; rts
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 3
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.l #%00000010,d0	;Set test bits
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; btst #0,d0				;Test bit 0
	; jsr showZero			;Show Zero flag to screen
	; btst #1,d0				;Test bit 1
	; jsr showZero			;Show Zero flag to screen
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; ;we don't need to reset D0 - because btst doesn't change it
	; bset #0,d0				;Test and Set bit 0
	; jsr showZero			;Show Zero flag to screen
	; bset #1,d0				;Test and Set bit 1
	; jsr showZero			;Show Zero flag to screen
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; move.l #%00000010,d0	;Set test bits
	; bclr #0,d0				;Test and Clear bit 0
	; jsr showZero			;Show Zero flag to screen
	; bclr #1,d0				;Test and Clear bit 1
	; jsr showZero			;Show Zero flag to screen
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; move.l #%00000010,d0	;Set test bits
	; bchg #0,d0				;Test and Flip bit 0
	; jsr showZero			;Show Zero flag to screen
	; bchg #1,d0				;Test and Flip bit 1
	; jsr showZero			;Show Zero flag to screen
	; jsr MonitorBitsD0	;show the results
	
	
	; jsr newline
	; move.l #0,d1			;We can use a bit number in another register too
	; move.l #1,d2
	
	; move.l #%00000010,d0	;Set test bits
	; bchg d1,d0				;Test and Flip bit 0
	; jsr showZero			;Show Zero flag to screen
	; bchg d2,d0				;Test and Flip bit 1
	; jsr showZero			;Show Zero flag to screen
	; jsr MonitorBitsD0	;show the results
	
	; jmp *					;Infloop

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 4
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	; move.l #%01101000,d0	;Set test bits
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	
	; rol.b #1,d0				;Rotate Left
	; jsr MonitorBitsD0		;show the results
	; rol.b #1,d0				;Rotate Left
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; ror.b #1,d0				;Rotate Right
	; jsr MonitorBitsD0		;show the results
	; ror.b #1,d0				;Rotate Right
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	; jsr newline
	
	; move.l #%01101000,d0	;Set test bits
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; lsl.b #1,d0				;shift Left
	; jsr MonitorBitsD0		;show the results
	; lsl.b #1,d0				;shift Left
	; jsr MonitorBitsD0		;show the results
	; jsr newline
		
	; lsr.b #1,d0				;shift Right
	; jsr MonitorBitsD0		;show the results
	; lsr.b #1,d0				;shift Right
	; jsr MonitorBitsD0		;show the results
	; jsr newline
	
	; jmp *					;Infloop
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;Example 5
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	move.l #$11111111,d0	;Set some test data
	move.l #$22222222,d1
	
	jsr MonitorD0			;show the results
	jsr MonitorD1
	jsr newline
	
	exg d0,d1				;Exchange two registers
	
	jsr MonitorD0			;show the results
	jsr MonitorD1
	jsr newline
	jsr newline
	
	move.l #$12345678,d0	;Set some test data
	jsr MonitorD0			;show the results
	
	swap d0					;Swap the two words
	
	jsr MonitorD0			;show the results
	
	jmp *					;Infloop
	
	
	
	
	
	
	
	
	
	
	
ShowZero:	
	moveM.l d0-d7/a0-a7,-(sp)
	Bne ShowZeroOne
	move.b #'0',d0
	jmp ShowZeroContinue
ShowZeroOne:
	move.b #'1',d0
ShowZeroContinue:
	jsr PrintChar
	jsr newline
	moveM.l (sp)+,d0-d7/a0-a7
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
	jsr newline
	rts
	
	
	
MonitorD0:				;Monitor D0 subroutine
	 move.l d0,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 jsr NewLine		;Newline
	 rts	
MonitorD1:				;Monitor D0 subroutine
	 move.l d1,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 jsr NewLine		;Newline
	 rts
MonitorD2:				;Monitor D0 subroutine
	 move.l d2,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 jsr NewLine		;Newline
	 rts
MonitorD3:				;Monitor D0 subroutine
	 move.l d3,-(sp)	;Push D0 onto the stack
	 jsr Monitor_PushedRegister	;Show pushed register
	 jsr NewLine		;Newline
	 rts
MonitorD4:				;Monitor D0 subroutine
	 move.l d4,-(sp)	;Push D0 onto the stack
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