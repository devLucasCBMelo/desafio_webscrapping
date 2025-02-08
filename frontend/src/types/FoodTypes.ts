export interface ComponentTypes {
  codigo: string,
  unidades: string,
  valorPor100g: string,
  colherSopaCheia45g: string,
  copoAmericanoDuplo200ml: string,
  copoAmericanoPequeno130ml: string,
  pedacoUnidadeFatia: string,
  pratoFundo450g: string,
  pratoRaso350g: string,
}

export interface CardType {
  cardName: 'EnergiaKJ' | 'Energiakcal' | 'Umidade' | 'Carboidrato Total' | 'Carboidrato Disponível' | 'Proteína' | 'Lipídios' | 'Fibra Alimentar' | 'Álcool' | 'Cinzas' | 'Colesterol' | 'Ácidos Graxos Saturados' | 'Ácidos Graxos Monoinsaturados' | 'Ácidos Graxos Poliinsaturados' ,
  infos: ComponentTypes
}