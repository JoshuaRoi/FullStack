import { ContactCard } from 'components/ContactCard'
import React from 'react'
import { useQuery } from "@tanstack/react-query";
import axios from 'axios';

export const Home = () => {
  const { data } = useQuery(
    {
      queryKey: ['contacts'],
      queryFn: async () => {
        const { data } = await axios.get(process.env.REACT_APP_BACKEND_URL!)
        return data
      },
      refetchInterval: false,
      refetchOnWindowFocus: false
    }
  )

  return (
    <div>
      Home{/* <ContactCard /> */}
    </div>
  )
}
