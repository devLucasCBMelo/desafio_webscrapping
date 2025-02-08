import { useEffect, useState } from "react";
import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { FoodCompositionContainer, FoodCompositionMain } from "./styles";
import { fetchFoodsComposition } from "../../utils/fetchFoodsCompsition";
import { FoodTypes } from "../../types/FoodTypes";
import { FoodInfosCard } from "../../components/FoodInfosCard/FoodInfosCard";

function FoodComposition() {
  const [foodCode, setFoodCode] = useState('');
  const [showFoodInfos, setShowFoodInfos] = useState<FoodTypes>({} as FoodTypes);

  useEffect(() => {}, [showFoodInfos])

  const handleSearchFood = async () => {
    const foundedFood = await fetchFoodsComposition(foodCode)
    setShowFoodInfos(foundedFood);
    console.log(foundedFood);
  }

  return (
    <FoodCompositionContainer>
      <Header />
      <FoodCompositionMain>
        <h3>Digite o código do alimento</h3>
        <input
          type="text"
          placeholder="Digite aqui o código do alimento"
          value={foodCode}
          onChange={(event) => setFoodCode(event.target.value)}
        />
        <button onClick={() => handleSearchFood()}>Procurar</button>

       <FoodInfosCard
          codigo={showFoodInfos.codigo}
          unidades={showFoodInfos.unidades}
          valorPor100g={showFoodInfos.valorPor100g}
          colherSopaCheia45g={showFoodInfos.colherSopaCheia45g}
          copoAmericanoDuplo200ml={showFoodInfos.copoAmericanoDuplo200ml}
          copoAmericanoPequeno130ml={showFoodInfos.copoAmericanoPequeno130ml}
          pedacoUnidadeFatia={showFoodInfos.pedacoUnidadeFatia}
          pratoFundo450g={showFoodInfos.pratoFundo450g}
          pratoRaso350g={showFoodInfos.pratoRaso350g}
      />
      </FoodCompositionMain>
      <Footer />
    </FoodCompositionContainer>
  )
}

export default FoodComposition;