ChibiSoundNoise:
	lea WaveFormNoise,a0
	move.l #WaveFormNoiseEnd-WaveFormNoise-1,d3
	
ChibiSoundReRandomize:
	;move.b #1,(a0)
	ifd getrandom
			jsr GetRandom	
			move.b d0,(a0)+	
	else
		addq.b #1,(a0)
		eor.b d0,(a0)
		eor.b d1,(a0)
		move.b (a6)+,d5
		eor.b d5,(a0)
		move.b (a0),d0
		ror.b #1,d0
		move.b d0,(a0)
		addq.l #1,a0
	endif
	dbra d3,ChibiSoundReRandomize
	;move.l (WaveFormNoise),d4
	
	rts



ChibiSound:					;NVVTTTTT	Noise Volume Tone 
	
	
	and.l #$000000FF,d0
	tst.b d0				;See if d0=0
	beq silent
	
	
	; jsr Monitor_MemDump;
	; dc.l WaveFormNoise
	; dc.w $6
	
	; jsr Monitor
	
	;move.w #(WaveFormEnd-WaveForm)/2,$DFF0A4
	
	
	
	move.w #WaveFormToneEnd-WaveFormTone,$DFF0A4		;Length
	move.w #WaveFormToneEnd-WaveFormTone,$DFF0A4+16 	;Length
	
	
	
	
	
	
	
	
	
	
	
	
	;        FEDCBA9876543210
	;move.w #%0000000011111111,$DFF09E


	
	move.b d0,d3 	;ld h,a

	move.b #%11001111,$C00011

	
	and.l #%00111111,d0
	rol.l #5,d0
	move.w d0,($DFF0A6)		;Period
	move.w d0,($DFF0A6+16)	;Period
	
	
	move.b d3,d0
	
	and.b #%01000000,d0		;Volume
	ror.b #1,d0
	eor.b #%00011111,d0 
	move.w d0,($DFF0A8)		;Volume (#64=max)
	move.w d0,($DFF0A8+16)	;Volume


	
	
	lea WaveFormTone,a0
	
	
	btst #7,d3				;bit 7,h
	beq ChibiSoundNoNoise			;jr z,AYNoNoise
	
	
	
		
	move.w #WaveFormNoiseEnd-WaveFormNoise,$DFF0A4		;Length
	move.w #WaveFormNoiseEnd-WaveFormNoise,$DFF0A4+16 	;Length
	
	
	
	
	jsr ChibiSoundNoise
	
	;jsr ChibiSoundNoise	
	lea WaveFormNoise,a0
ChibiSoundNoNoise:
	move.l a0,($DFF0A0)		;Location
	move.l a0,($DFF0A0+16)	;Location


	;        FEDCBA9876543210
	move.w #%1000001000000011,$DFF096	;DMA Control
	
	rts

silent:
	;ld a,%11111111	;1CCTVVVV	(Latch - Channel Type Volume)	
	;out (&7F),a
	;ld a,%11011111	;1CCTVVVV	(Latch - Channel Type Volume)	
	;out (&7F),a
	;ret
	clr.w ($DFF0A8)		;Volume (#64=max)
	clr.w ($DFF0A8+16)	;Volume



	rts
	
;	$C00011 		SN76489 PSG 
; AUD0LCH	+	0A0	W	A( E )	Audio channel 0 location (high 3 bits, 5 if ECS)
; AUD0LCL	+	0A2	W	A	Audio channel 0 location (low 15 bits)
; AUD0LEN		0A4	W	P	Audio channel 0 length
; AUD0PER		0A6	W	P( E )	Audio channel 0 period
; AUD0VOL		0A8	W	P	Audio channel 0 volume
; AUD0DAT	&	0AA	W	P	Audio channel 0 data
