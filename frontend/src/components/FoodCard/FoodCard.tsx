import { CardFoodType } from "../../types/FoodTypes";
import { FoodCardContainer } from "./styles";

const FoodCard = ({ codigo, nome, nomeCientifico, grupo, marca }: CardFoodType) => {
  return (
    <FoodCardContainer>
      <h4>Código</h4>
      <p>{codigo}</p>

      <h4>Nome</h4>
      <p>{nome}</p>

      <h4>Nome Científico</h4>
      <p>{nomeCientifico}</p>

      <h4>Grupo</h4>
      <p>{grupo}</p>

      <h4>Marca</h4>
      <p>{marca}</p>
    </FoodCardContainer>
  )
}

export default FoodCard;