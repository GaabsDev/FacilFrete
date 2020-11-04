import { DomainBase } from "../domain/base/base.domain";
import { ObjectMapper, JsonProperty } from "json-object-mapper";

export class RaioPreco extends DomainBase {
  @JsonProperty({ name: "Latitude" })
  public Latitude: number;
  @JsonProperty({ name: "Longitude" })
  public Longitude: number;
  @JsonProperty({ name: "Raio" })
  public Raio: number;
  @JsonProperty({ name: "Preco" })
  public Preco: number = 0.0;
  @JsonProperty({ name: "IdCentroDistribuicao" })
  public IdCentroDistribuicao: number;
  @JsonProperty({ name: "Descricao" })
  public Descricao: number;

  static Create(json: any): RaioPreco {
    return ObjectMapper.deserialize<RaioPreco>(RaioPreco, json);
  }
}
