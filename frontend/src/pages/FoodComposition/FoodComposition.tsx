import { useEffect, useState } from "react";
import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { FoodCompositionContainer, FoodCompositionMain } from "./styles";
import { fetchFoodsComposition } from "../../utils/fetchFoodsCompsition";
import { FoodInfosCard } from "../../components/FoodInfosCard/FoodInfosCard";
import { ComponentTypes } from "../../types/FoodTypes";

function FoodComposition() {
  const [foodCode, setFoodCode] = useState('');
  const [showFoodInfos, setShowFoodInfos] = useState<ComponentTypes>({} as ComponentTypes);

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
          cardName="EnergiaKJ"
          infos={showFoodInfos}
      />
      </FoodCompositionMain>
      <Footer />
    </FoodCompositionContainer>
  )
}

export default FoodComposition;