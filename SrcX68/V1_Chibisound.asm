;$E90000		FM Synthesizer (YM2151)

	
ChibiSoundSilent:
	move.b #$60+24+7,$E90001 
	;        -VVVVVVV			;[Slot] Volume (0=Max)
	move.l #%01111111,d0
	move.b d0,$E90003
	
	rts
ChibiSound:					;NVVTTTTT	Noise Volume Tone 
	and.l #$000000FF,d0
	beq ChibiSoundSilent
	eor.b #%00111111,d0
	move.l d0,d1

	move.b #$20,$E90001			;FM Operation
;	         LRFFFCCC
	move.b #%11000000,$E90003	;Left/Right Feedback,Connection

	move.b #$28+7,$E90001
	
	
	move.l d1,d0
	and.b #%00111111,d0
	rol #1,d0
	;        -OOONNNN			;Key Octive + Note
	move.b d0,$E90003
	
	move.b #$30+7,$E90001
	;        FFFFFF--			;Key Fraction
	;move.b #%11111100,$E90003
	
	move.b #$38+7,$E90001
	;        -PPP--AA			;Amptliture modulation sensitivity AMS
	;move.b #%01110011,$E90003
	
	;move.b #$40+24,$E90001
	;        -DDDMMMM			; [Slot] Decay / Mult
	;move.b #%00110001,$E90003

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
	
	move.b #$60+24+7,$E90001 
	;        -VVVVVVV			;[Slot] Volume (0=Max)
	move.l d1,d0
	and.b #%01000000,d0
	eor.b #%01000000,d0
	ror #2,d0
	move.b d0,$E90003

	move.b #$80+24+7,$E90001
	;        KK-AAAAA			;[Slot] KeyScaling / Attack Rate (TA)
	;move.b #%11011111,$E90003
		
	move.b #$A0+24+7,$E90001
	;        A-DDDDDD			;[Slot] Decay / AMS-EN
	;move.b #%00111111,$E90003
		
	move.b #$C0+24+7,$E90001
	;        TT-DDDDD			;[Slot] Decay / deTune
	;move.b #%00011111,$E90003
	
	move.b #$E0+24+7,$E90001
	;        DDDDRRRR			;[Slot] Decay / Release rate (16=Constant tone)
	move.b #%00001111,$E90003
	
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


	move.b #$60+16+7,$E90001 
	;        -VVVVVVV			;[Slot] Volume (0=Max)
	move.b #%00000000,$E90003
	
	move.b #$A0+16+7,$E90001
	;        A-DDDDDD			;[Slot] Decay / AMS-EN
	move.b #%00111111,$E90003
		
	move.b #$C0+16+7,$E90001
	;        TT-DDDDD			;[Slot] Decay / deTune
	move.b #%00011111,$E90003
	
	move.b #$E0+16+7,$E90001
	;        DDDDRRRR			;[Slot] Decay / Release rate (16=Constant tone)
	move.b #%00001111,$E90003

;;;;;;;;;;;;;;;
	
	move.b #$60+8+7,$E90001 
	;        -VVVVVVV			;[Slot] Volume (0=Max)
	move.b #%00001111,$E90003

	move.b #$A0+8+7,$E90001
	;        A-DDDDDD			;[Slot] Decay / AMS-EN
	move.b #%00000000,$E90003
		
	move.b #$C0+8+7,$E90001
	;        TT-DDDDD			;[Slot] Decay / deTune
	move.b #%00000000,$E90003
	
	move.b #$E0+8+7,$E90001
	;        DDDDRRRR			;[Slot] Decay / Release rate (16=Constant tone)
	move.b #%00001111,$E90003

;;;;;;;;;;;;;;;

	move.b #$60+0+7,$E90001 
	;        -VVVVVVV			;[Slot] Volume (0=Max)
	move.b #%00001111,$E90003

	move.b #$A0+0+7,$E90001
	;        A-DDDDDD			;[Slot] Decay / AMS-EN
	move.b #%00000000,$E90003
		
	move.b #$C0+0+7,$E90001
	;        TT-DDDDD			;[Slot] Decay / deTune
	move.b #%00000000,$E90003
	
	move.b #$E0+0+7,$E90001
	;        DDDDRRRR			;[Slot] Decay / Release rate (16=Constant tone)
	move.b #%00001111,$E90003



;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

;	move.b #$19,$E90001
	;        DDDDDDDD 		;PMD/AMD
;	move.b #%00000100,$E90003
	
	move.b #$1B,$E90001
;	         CC----WW 		;WaveForm / CC=CT
	move.b #%11000001,$E90003
	
	
	move.b #$0F,$E90001
	;        E--FFFFF 		;Noise Enable Freq (Slot 32 - channel 8)
	move.b #%00000000,$E90003
	
	move.b #$08,$E90001
	;        -SSSSCCC
	move.b #%01100111,$E90003	;Channel / Slot ( C2 - M2 - C1 - M1 )

	; Channel 1 - M1 uses Sot 1, C1=9 , M2=17, C2=25
	
	move.l d1,d0
	and.b #%10000000,d0
	bne ChibiSoundNoiseOn
	rts
ChibiSoundNoiseOn:
	
	move.b #$0F,$E90001

	move.l d1,d0
	and.b #%00111110,d0
	ror #1,d0
	or.b  #%10000000,d0
	
	move.b d0,$E90003
	;        E--FFFFF 		;Noise Enable Freq (Slot 32 - channel 8)
	
	
	rts


























	and.l #$000000FF,d0
	tst.b d0				;See if d0=0
	beq silent
	move.l d0,d3;ld h,a
	and.b #%00000111,d0
	ror.b #3,d0				;rrca
							;rrca
							;rrca
	or.b #%00011111,d0
	move.b d0,d1
	move.b #0,d0			;TTTTTTTT Tone Lower 8 bits	A
	;jsr SetAYRegister

	move.b d3,d0
	and.b #%00111000,d0
	ror.b #3,d0				;rrca
							;rrca
							;rrca
	move.b d0,d1			;ld c,a
	move.b #1,d0			;ld a,1			;----TTTT Tone Upper 4 bits
	;jsr SetAYRegister		;call RegWrite
	jsr monitor
	btst #7,d3				;bit 7,h
	beq AYNoNoise			;jr z,AYNoNoise

	move.b #7,d0			;ld a,7			;Mixer  --NNNTTT (1=off) --CBACBA
	move.b #%00110110,d1	;ld c,%00110110
;	jsr SetAYRegister		;call RegWrite

	move.b #6,d0			;ld a,6			;Noise ---NNNNN
	move.b #%00011111,d1	;ld c,%00011111
;	jsr SetAYRegister		;call RegWrite


	jmp AYMakeTone
AYNoNoise:
	move.b #7,d0			;Mixer  --NNNTTT (1=off) --CBACBA
	move.b #%00111110,d1
	;jsr SetAYRegister		;call RegWrite
	jmp AYMakeTone
AYMakeTone:
	;*** these are incorrectly marked as Amplitude Control (Registers R10,R11,R12) in some documentation! ***
	move.b d3,d0
	and.b #%01000000,d0
	ror.b #4,d0				;rrca
							;rrca
							;rrca
							;rrca
	or.b #%00001011,d0
	move.b d0,d1
	move.b #8,d0			;4-bit Volume / 2-bit Envelope Select for channel A ---EVVVV
	;jsr SetAYRegister		;call RegWrite
	rts
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
silent:
	move.b #7,d0			;Mixer  --NNNTTT (1=off) --CBACBA
	move.b #%00111111,d1
	;jsr SetAYRegister		;call RegWrite
	rts
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;