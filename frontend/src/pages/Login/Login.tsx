import { useNavigate } from "react-router-dom";
import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { LoginContainer, LoginForm, LoginMain } from "./styles";
import { useEffect } from "react";
import { fetchFoodDatabase } from "../../utils/fetchFoodDatabase";
import { fetchComponentsDatabase } from "../../utils/fetchComponentsDatabase";

function Login() {
  const navigate = useNavigate();

  useEffect(() => {
    const callFoods = async () => {
      await fetchFoodDatabase();
    }

    const callComponents = async () => {
      await fetchComponentsDatabase();
    }

    callFoods();
    callComponents();
  }, [])

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    navigate('/foodcomposition')
  }
  return (
    <LoginContainer>
      <Header />
      <LoginMain>
        <h1>Faça seu login abaixo</h1>
        <LoginForm onSubmit={(event) => handleSubmit(event)}>
          <label htmlFor="input-email">
            E-mail
            <input id="input-email" type="email"  placeholder="Digite seu e-mail" required/>
          </label>
          <label htmlFor="input-password">
            Senha
            <input id="input-password" type="password" placeholder="Digite sua senha" required/>
          </label>
          <button type="submit">Entrar</button>
        </LoginForm>
      </LoginMain>
      <Footer />
    </LoginContainer>
  )
}

export default Login;