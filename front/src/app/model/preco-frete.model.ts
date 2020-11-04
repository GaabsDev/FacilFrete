import { ObjectMapper, JsonProperty } from "json-object-mapper";

export class PrecoFrete {
  @JsonProperty({ name: "distancia" })
  public Distancia: number = 0;
  @JsonProperty({ name: "preco" })
  public Preco: number = 0;
  @JsonProperty({ name: "descricao" })
  public Descricao: string = "";
  @JsonProperty({ name: "codigo" })
  public Codigo: string = "";
  @JsonProperty({ name: "idCentroDistribuicao" })
  public IdCentroDistribuicao: number = 0;

  static Create(json: any): PrecoFrete {
    let obj = ObjectMapper.deserialize<PrecoFrete>(PrecoFrete, json);
    return obj;
  }
}
