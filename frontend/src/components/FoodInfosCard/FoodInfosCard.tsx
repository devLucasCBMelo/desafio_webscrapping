import { FoodTypes } from "../../types/FoodTypes"
import { FoodInfosCardContainer } from "./styles"

export const FoodInfosCard = ({ 
  codigo,
  unidades,
  colherSopaCheia45g,
  copoAmericanoDuplo200ml,
  copoAmericanoPequeno130ml,
  pedacoUnidadeFatia,
  pratoFundo450g,
  pratoRaso350g}: FoodTypes) => {
  return (
    <FoodInfosCardContainer>
      <p>{codigo}</p>
      <p>{unidades}</p>
      <p>{colherSopaCheia45g}</p>
      <p>{copoAmericanoDuplo200ml}</p>
      <p>{copoAmericanoPequeno130ml}</p>
      <p>{pedacoUnidadeFatia}</p>
      <p>{pratoFundo450g}</p>
      <p>{pratoRaso350g}</p>
    </FoodInfosCardContainer>
  )
}