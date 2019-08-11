ChibiSound:					;NVTTTTTT	Noise Volume Tone 
	and.l #$000000FF,d0
	tst.b d0				;See if d0=0
	beq silent
	
	move.b d0,d3		  
			;1CCTLLLL	(Latch - Channel Type DataL
	move.b #%11001111,$C00011

	and.b  #%00111111,d0		;Get Tone H
	move.b d0,$C00011

	move.b d3,d0
	and.b #%01000000,d0			;Volume bit
	ror.b #4,d0
	move.b d0,d2				;backup for noise
	eor.b #%11010100,d0 
	move.b d0,$C00011			;Set Volume

			;1CCTVVVV	(Latch - Channel Type Volume)	
	move.b #%11111111,$C00011

	btst #7,d3			
	beq ChibiSoundNoNoise	
	
	move.b d3,d0				;Noise Generator seems to be different on Genesis compared to others!
	and.b #%00000111,d0			;Slowest noise is too slow!
	rol #1,d0
	or.b  #%11000001,d0			;Low Noise Freq
	move.b d0,$C00011
	
	move.b d3,d0
	and.b #%00111000,d0
	ror #3,d0
	move.b d0,$C00011			;High Noise Freq
	
			;1CCTVVVV	(Latch - Channel Type Volume)	
	move.b #%11011111,$C00011	;Mute Tone
	move.b #%11100111,$C00011	;Enable Noise (White - linked to channel 2)
	
	move.b d2,d0				;Noise volume
	eor.b #%11110100,d0 
	move.b d0,$C00011			;Set Volume
ChibiSoundNoNoise:
	rts

silent:		;Mute Nosie and Tone (Vol 15=mute)
			;1CCTVVVV
	move.b #%11111111,$C00011	;(Latch - Channel Type Volume)	
	move.b #%11011111,$C00011	;(Latch - Channel Type Volume)	
	rts
	
;LCCTDDDD	Format Template	L=Latch C=Channel T=Type XXXX=Data

;1CC0LLLL	Tone - Command 1/2C=Channel L=tone Low data
;0-HHHHHH	Tone - Command 2/2H= High tone data (Higher numbers = lower tone)
;1CC1VVVV	Volume C=Channel (0-2)  V=Volume (15=silent 0=max)
;1110-MRR	Noise Channel(Channel 3)  M=Noise mode (1=white) R=Rate (3=use tone 2)	
	
	