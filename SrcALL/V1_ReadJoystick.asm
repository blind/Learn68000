	ifd BuildX68
		include "\SrcX68\V1_ReadJoystick.asm"
	endif
	ifd BuildNEO
		include "\SrcNEO\V1_ReadJoystick.asm"
	endif
	ifd BuildAMI
		include "\SrcAMI\V1_ReadJoystick.asm"
	endif
	ifd BuildAST
		include "\SrcAST\V1_ReadJoystick.asm"
	endif
	ifd BuildGEN
		include "\SrcGEN\V1_ReadJoystick.asm"
	endif
	ifd BuildSQL
		include "\SrcSQL\V1_ReadJoystick.asm"
	endif