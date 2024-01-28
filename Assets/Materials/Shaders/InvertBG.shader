Shader "InvertBG" {

  SubShader {

    Tags {"Queue"="Transparent" "IgnoreProjector"="True"} 
    ZWrite Off Blend SrcAlpha OneMinusSrcAlpha

    Pass {

      CGPROGRAM
      
      struct v2f {
        float4 pos : SV_POSITION;
      };

      v2f vert(appdata_base v) {
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        return o;
      }

      fixed4 frag(v2f i) : SV_Target {
        return fixed4(1,1,1,1);
      }

      ENDCG

    }

    Pass {

      CGPROGRAM

      Stencil {
        Ref 1
        Comp NotEqual
      }
      
      struct v2f {
        float4 pos : SV_POSITION;
      };

      fixed4 frag(v2f i) : SV_Target {
        return fixed4(0,0,0,0);
      }

      ENDCG
      
    }

  }

}