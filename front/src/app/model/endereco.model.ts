import { DomainBase } from "../domain/base/base.domain";

export class EnderecoModel extends DomainBase {

  public CEP: string;
  public Logradouro: string;
  public Complemento: string;
  public Bairro: string;
  public Cidade: string;
  public Uf: string
  public Numero: number;

  constructor(data: any = {}) {
    super();

    if (data == null) {
      data = {};
    }

    this.CEP = data.cep || data.Cep || data.CEP;
    this.Logradouro = data.logradouro || data.Logradouro || data.LOGRADOURO;
    this.Complemento = data.complemento || data.Complemento || data.COMPLEMENTO;
    this.Bairro = data.bairro || data.Bairro;
    this.Cidade = data.cidade || data.Cidade;
    this.Uf = data.uf || data.Uf;
    this.Numero = data.numero || data.Numero;
  }
}