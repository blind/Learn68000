ChibiSound:					;NVTTTTTT	Noise Volume Tone 
	
	;we use CH1 OP4 ($xC) for the tone
	;we use CH1 OP1 ($x0) for the noise

	; Disable the Z80
	move.w  #$100,$a11100	;Z80 Bus REQ
	move.w  #$100,$a11200	;Z80 Reset

	and.l #$000000FF,d0
	tst.b d0				;See if d0=0
	beq silent
	movem.l d0-d3/a1,-(sp)
		eor.b #%00111111,d0
		move.b d0,d3		

		;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
		
		move.b #$B0,d0
				;--FFFAAA	F=Feedback / A=Algorithm		/-> OP2 \
								;Algorithm 5				OP1 --> OP3  -->
		jsr SNDSetReg1		  ;  							\-> OP4 /

		move.b #$30,d0
				;-DDDMMMM	D=Detune / M=Multiplier
		move.b #%00000011,d1  ;Multiplier=3 (noise)
		jsr SNDSetReg1

		move.b #$3C,d0
				;-DDDMMMM	D=Detune / M=Multiplier
		move.b #%00000001,d1  ;Multiplier = 1 (tone)
		jsr SNDSetReg1
		
		move.b #$50,d0
				;RR-AAAAA	R=Rate Scaling / A = Attack rate
		move.b #%00011111,d1  ;Attack Rate=31 (noise)
		jsr SNDSetReg1
		
		move.b #$5C,d0
				;RR-AAAAA	R=Rate Scaling / A = Attack rate
		move.b #%00011111,d1  ;Attack Rate=31 (tone)
		jsr SNDSetReg1
		
		
		move.b #$6C,d0
				;A--DDDDD	A=Amplitude Mod Enable / D= Decay rate
		move.b #%10000000,d1  ;0= Keep tone constant (allow LFO)
		jsr SNDSetReg1
		
		
		move.b #$80,d0
				;SSSSRRRR	S=Sustain Level / Release Rate
		move.b #%11111111,d1  ;Sustain=15 , Release=15
		jsr SNDSetReg1
		
		
		move.b #$8C,d0
				;SSSSRRRR	S=Sustain Level / Release Rate
		move.b #%11111111,d1  ;Sustain=15 , Release=15
		jsr SNDSetReg1
		
		
		
	;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

		move.b d3,d0
		and #%10000000,d0
		beq ChibiSoundNoNoise

ChibiSoundNoise:		
		move.b #$22,d0 
				;----EFFF	E=enable F=frequency
		move.b #%00001110,d1  ;Turn on LFO
		jsr SNDSetReg1
		
		move.b #$B4,d0
				;LRAA-FFF	Left / Right (1=on) / A=Amplitude Mod Sensitivity / F=Frequency Mod Sensitivity
		move.b #%11110100,d1  ;Stereo output - LFO Amplitude Mod ON
		jsr SNDSetReg1
		
		move.b #$28,d0
				;OOOO-GCC	O=operator / GCCC=Channel (%010=chn 3 %100=Chn4)
		move.b #%10010000,d1  ;KEY ON (OP4 Tone + OP1 Noise)
		jsr SNDSetReg1
		
		bra ChibiSoundNoiseDone
ChibiSoundNoNoise:
	
	
		move.b #$22,d0 
				;----EFFF	E=enable F=frequency
		move.b #%00000000,d1  ;Global: LFO disable
		jsr SNDSetReg1
		
		move.b #$B4,d0
				;LRAA-FFF	Left / Right (1=on) / A=Amplitude Mod Sensitivity / F=Frequency Mod Sensitivity
		move.b #%11000000,d1  ;Stereo output
		jsr SNDSetReg1
		
		move.b #$28,d0
				;OOOO-GCC	O=operator / GCCC=Channel (%010=chn 3 %100=Chn4)
		move.b #%10000000,d1  ;KEY ON (OP 4 Tone)
		jsr SNDSetReg1
		
ChibiSoundNoiseDone:		


		move.b d3,d1

		and.b #%00110000,d1
		ror.b #4,d1
		or.b #%00011100,d1
		move.b #$A4,d0		;--OOOPPP	O=Octive / P=Position H - Frequency MSB
		jsr SNDSetReg1
		
		
		move.b d3,d1
		and.b #%00001111,d1
		rol.b #4,d1
		move.b #$A0,d0		;PPPPPPPP	P=Frequency Position L - Frequency LSB
		jsr SNDSetReg1
		
		move.b d3,d1
		and.b #%01000000,d1
		eor.b #%01000000,d1
		ror.b #2,d1
		
		move.b #$4C,d0		;-TTTTTTT	T=Total Level (0=largest) - Volume of Op4
		jsr SNDSetReg1
	
	movem.l (sp)+,d0-d3/a1
	
	rts

silent:		;Mute Nosie and Tone (Vol 15=mute)

	move.b #$28,d0
			;OOOO-CCC	O=operator / C=Channel (0=chn 1)
	move.b #%00000000,d1  ;KEY ON
	jsr SNDSetReg1
	
	move.b #$B4,d0
			;LRAA-FFF	Left / Right (1=on) / A=Amplitude Mod Sensitivity / F=Frequency Mod Sensitivity
	move.b #%00000000,d1  ;Stereo output
	jsr SNDSetReg1
	
	rts
	
;LCCTDDDD	Format Template	L=Latch C=Channel T=Type XXXX=Data

;1CC0LLLL	Tone - Command 1/2C=Channel L=tone Low data
;0-HHHHHH	Tone - Command 2/2H= High tone data (Higher numbers = lower tone)
;1CC1VVVV	Volume C=Channel (0-2)  V=Volume (15=silent 0=max)
;1110-MRR	Noise Channel(Channel 3)  M=Noise mode (1=white) R=Rate (3=use tone 2)	
	
	
	move.b #$28,d0
			;OOOO-CCC	O=operator / C=Channel (0=chn 1)
	move.b #%00000000,d1  ;KEY OFF
	jsr SNDSetReg1
	
	move.b #$22,d0 
			;----EFFF	E=enable F=frequency
	move.b #%00001111,d1  ;Global: LFO disable
	jsr SNDSetReg1
	
	
	
	
	move.b #$B0,d0
			;--FFFAAA	F=Feedback / A=Algorithm
	move.b #%00110000,d1  ;Algorithm, Feedback <- pure sine wave
	jsr SNDSetReg1
	
	move.b #$3C,d0
			;-DDDMMMM	D=Detune / M=Multiplier
	move.b #%00000001,d1  ;Operator 4.MUL = 1
	jsr SNDSetReg1
	
	move.b #$B4,d0
			;LRAA-FFF	Left / Right (1=on) / A=Amplitude Mod Sensitivity / F=Frequency Mod Sensitivity
	move.b #%11000111,d1  ;Stereo output
	jsr SNDSetReg1
	
	move.b #$44,d0
			;-TTTTTTT	T=Total Level (0=largest)
	move.b #%01111111,d1  ;Mute operator 3  <- pure sine wave
	jsr SNDSetReg1
	
	move.b #$4C,d0
			;-TTTTTTT	T=Total Level (0=largest)
	move.b #%00000000,d1  ;Max volume for operator 4
	jsr SNDSetReg1
	
	move.b #$5C,d0
			;RR-AAAAA	R=Rate Scaling / A = Attack rate
	move.b #%00011111,d1  ;Operator 4.AR = shortest
	jsr SNDSetReg1
	
	move.b #$6C,d0
			;A--DDDDD	A=Amplitude Mod Enable / D= Decay rate
	move.b #%10000000,d1  ;0= Keep tone constant (allow LFO)
	jsr SNDSetReg1
	
	move.b #$7C,d0
			;---SSSSS	S=Sustain Rate
	move.b #%00011111,d1  ;Operator 4.D2R= 31
	jsr SNDSetReg1
	
	move.b #$8C,d0
			;SSSSRRRR	S=Sustain Level / Release Rate
	move.b #%11111111,d1  ;Operator 4.SL = 15 / Operator4. RR=15
	jsr SNDSetReg1
	
	move.b #$A4,d0
			;--OOOPPP	O=Octive / P=Position H
	move.b #%00011111,d1  ;Frequency MSB
	jsr SNDSetReg1
	
	move.b #$A0,d0	
			;PPPPPPPP	P=Frequency Position L
	move.b #%11111111,d1  ;Frequency LSB
	jsr SNDSetReg1
	
	move.b #$28,d0
			;OOOO-CCC	O=operator / C=Channel (0=chn 1)
	move.b #%10000000,d1  ;KEY ON
	jsr SNDSetReg1
	
	
	jmp *
	
SNDSetReg1:
	move.l #$A04000,a0
	jsr SNDSetRegpause
	move.b d0,(a0)
	jsr SNDSetRegpause
	move.b d1,(1,a0)
	rts
SNDSetRegpause:
	move.b (a0),d2
	btst #7,d2
	bne SNDSetRegpause
	rts