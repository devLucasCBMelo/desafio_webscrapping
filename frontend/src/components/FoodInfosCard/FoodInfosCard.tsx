import { CardInfosType } from "../../types/FoodTypes"
import { FoodInfosCardContainer } from "./styles"

export const FoodInfosCard = ( {cardName, infos} : CardInfosType) => {
  return (
    <FoodInfosCardContainer>
      <h3>{cardName}</h3>
      <p>{infos.codigo}</p>
      <p>{infos. unidades}</p>
      <p>{infos.colherSopaCheia45g}</p>
      <p>{infos.copoAmericanoDuplo200ml}</p>
      <p>{infos.copoAmericanoPequeno130ml}</p>
      <p>{infos.pedacoUnidadeFatia}</p>
      <p>{infos.pratoFundo450g}</p>
      <p>{infos.pratoRaso350g}</p>
    </FoodInfosCardContainer>
  )
}