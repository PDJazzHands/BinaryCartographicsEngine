sampler s0;

float4 ForeColor;
float4 BackColor;

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(s0, coords);
	color = (BackColor.a * (1.0f - color.a) * BackColor) + color.a * (ForeColor * color);

	return color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}
