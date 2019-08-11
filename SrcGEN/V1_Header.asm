

UserRam equ $00FF0000


; hello.asm

;		LIST	OFF;
;		INCLUDE	gen.h
;		LIST	ON
VDP_data	EQU	$C00000	; VDP data, R/W word or longword access only
VDP_ctrl	EQU	$C00004	; VDP control, word or longword writes only

;-----------------------------------------------------------------------
;	exception vectors
;-----------------------------------------------------------------------


	DC.L	$FFFFFE00	; startup SP
	DC.L	START		; startup PC

	DS.L	7,RTEnn		; bus,addr,illegal,divzero,CHK,TRAPV,priv
	DC.L	RTEnn		; trace
	DC.L	RTEnn		; line 1010 emulator
	DC.L	RTEnn		; line 1111 emulator
	DS.L	4,RTEnn		; unassigned/uninitialized
	DS.L	8,RTEnn		; unassigned
	DC.L	RTEnn		; spurious interrupt
	DC.L	RTEnn		; interrupt level 1 (lowest priority)
	DC.L	ExtInt		; interrupt level 2 = external interrupt
	DC.L	RTEnn		; interrupt level 3
	DC.L	HSync		; interrupt level 4 = H-sync interrupt
	DC.L	RTEnn		; interrupt level 5
	DC.L	VSync		; interrupt level 6 = V-sync interrupt
	DC.L	RTEnn		; interrupt level 7 (highest priority)
	DS.L	16,RTEnn		; TRAP instruction vectors
	DS.L	16,RTEnn		; unassigned

;-----------------------------------------------------------------------
;	cartridge info header
;-----------------------------------------------------------------------

	DC.B	"SEGA GENESIS    "	; must start with "SEGA"
	DC.B	"(C)---- "		; copyright
 	DC.B	"2006.DEC"		; date
	DC.B	"Chibiakumas.com                                 " ; cart name
	DC.B	"Chibiakumas.com                                 " ; cart name (alt. language)
	DC.B	"GM MK-0000 -00"	; program type / catalog number
	DC.W	$0000			; ROM checksum
	DC.B	"J               "	; hardware used
	DC.L	$00000000		; start of ROM
	DC.L	$003FFFFF		; end of ROM
	DC.L	$00FF0000,$00FFFFFF	; RAM start/end
	DC.B	"            "		; backup RAM info
	DC.B	"            "		; modem info
	DC.B	"                                        " ; comment
	DC.B	"JUE             "	; regions allowed

;-----------------------------------------------------------------------
;	generic exception handler
;-----------------------------------------------------------------------

ExtInt
HSync
VSync
RTEnn
	RTE
;-----------------------------------------------------------------------
;	main entry point
;-----------------------------------------------------------------------

START
		
;		MOVEM.L	(A5)+,D5-D7/A0-A4

		; initialize TMSS
		MOVE.B	($A10001),D0		; A10001 test the hardware version
		ANDI.B	#$0F,D0
		BEQ	NoTmss					; branch if no TMSS
		MOVE.L	#'SEGA',($A14000)	; A14000 disable TMSS
NoTmss

		jsr ScreenINIT
