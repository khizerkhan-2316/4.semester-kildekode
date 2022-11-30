using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model;

namespace DataAccessLayer.Mappers
{
	public class PictureMapper
	{

		public PictureDto Map(Picture picture)
		{
			PictureDto dto = new PictureDto(picture.Title, picture.ImagePath);
			dto.PictureId = picture.PictureId;

			return dto;
		}
	}
}
