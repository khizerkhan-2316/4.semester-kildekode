using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class PictureController
	{

		private static PictureController instance;
		private readonly PictureRepository repository;


		private PictureController()
		{
			repository = new PictureRepository();	
		}

		public static PictureController GetController() {

			if (instance == null)
			{
				instance = new PictureController();
			}

			return instance;
		}

		public void SavePicture(PictureDto picture)
		{
			Picture created = new Picture(picture.Title, picture.ImagePath);
			created.ImageFile = picture.ImageFile;
			created.PictureId= picture.PictureId;
			repository.InsertEntity(created);

		}

		public string GetImagePath(PictureDto picture)
		{
			string fileName = Path.GetFileNameWithoutExtension(picture.ImageFile.FileName);
			string extension = Path.GetExtension(picture.ImageFile.FileName);
			fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
			return fileName;

		}

		public string GetImageTitle(PictureDto picture)
		{
			return Path.GetFileNameWithoutExtension(picture.ImageFile.FileName);
		}

		public PictureDto GetDefaultImage()
		{
			return repository.GetDefaultImage();
		}

	}
}
