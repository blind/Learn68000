	ifd BuildAST
		include "\SrcAST\V1_BitmapMemory.asm"
	endif
	ifd BuildAMI
		include "\SrcAMI\V1_BitmapMemory.asm"
	endif
	ifd BuildX68
		include "\SrcX68\V1_BitmapMemory.asm"
	endif
	