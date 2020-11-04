import { JsonProperty, ObjectMapper } from "json-object-mapper";

export abstract class DomainBase {
  @JsonProperty({ name: "Id" })
  public Id: number = 0;
}
